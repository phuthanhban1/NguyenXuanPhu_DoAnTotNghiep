using Application.Dtos.ImageFileDtos;
using Application.Dtos.UserDtos;
using Application.Exceptions;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services.Implements
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<bool> CheckUserByEmail(string email)
        {
            var getUserEmail = await _unitOfWork.Users.FindAsync(u => u.Email == email);
            if(getUserEmail == null || !getUserEmail.Any())
            {
                return false;
            }
            return true;
        }
        public async Task AddAsync(UserCreateDto userCreateDto)
        {
            try
            {
                if(await CheckUserByEmail(userCreateDto.Email))
                {
                    throw new BadRequestException("Email đã tồn tại");
                }
                var user = _mapper.Map<User>(userCreateDto);
                user.Id = Guid.NewGuid();
                user.RoleId = new Guid("8A7DD16F-85BF-4143-BE0B-A31DA3BBE44A");

                var imageFace = await ExtensionService.GetImageFile(userCreateDto.ImageFace);
                user.ImageFaceId = imageFace.Id;
                await _unitOfWork.ExamFiles.AddAsync(imageFace);

                var imageBefore = await ExtensionService.GetImageFile(userCreateDto.ImageIdCardBefore);
                user.ImageIdCardBeforeId = imageBefore.Id;
                await _unitOfWork.ExamFiles.AddAsync(imageBefore);

                var imageAfter = await ExtensionService.GetImageFile(userCreateDto.ImageIdCardAfter);
                user.ImageIdCardAfterId = imageAfter.Id;
                await _unitOfWork.ExamFiles.AddAsync(imageAfter);

                user.IsActive = true;
                await _unitOfWork.Users.AddAsync(user);
                await _unitOfWork.SaveChangeAsync();
            }
            catch (Exception e)
            {
                throw new BadRequestException("Có lỗi", e);
            }
        }

        public async Task UpdateAsync(UserUpdateDto userUpdateDto)
        {
            try
            {
                var user = await _unitOfWork.Users.GetByIdAsync(userUpdateDto.Id);
                if (user == null)
                {
                    throw new NotFoundException($"Không tìm thấy người dùng có id: {userUpdateDto.Id}");
                }
                else
                {
                    // image face
                    var imageFace = await ExtensionService.GetImageFile(userUpdateDto.ImageFace);
                    imageFace.Id = (Guid)user.ImageFaceId;
                    await _unitOfWork.ExamFiles.UpdateAsync(imageFace);

                    //image before
                    var imageBefore = await ExtensionService.GetImageFile(userUpdateDto.ImageIdCardBefore);
                    imageBefore.Id = (Guid)user.ImageIdCardBeforeId;
                    await _unitOfWork.ExamFiles.UpdateAsync(imageBefore);

                    // image after
                    var imageAfter = await ExtensionService.GetImageFile(userUpdateDto.ImageIdCardAfter);
                    imageAfter.Id = (Guid)user.ImageIdCardAfterId;
                    await _unitOfWork.ExamFiles.UpdateAsync(imageAfter);

                    _mapper.Map(userUpdateDto, user);
                    await _unitOfWork.Users.UpdateAsync(user);

                    await _unitOfWork.SaveChangeAsync();
                }
            }
            catch (Exception e)
            {
                throw new BadRequestException("Có lỗi", e);
            }
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GetAllUserDto>> GetAllAsync()
        {
            var listUsers = await _unitOfWork.Users.GetAllAsync();
            return _mapper.Map<List<GetAllUserDto>>(listUsers);

        }

        public UserDto GetById(Guid id)
        {
            var users = _unitOfWork.Users.GetById(id)
                .Include(u => u.ImageFace)
                .Include(u => u.ImageIdCardBefore)
                .Include(u => u.ImageIdCardAfter);
            var user = users.FirstOrDefault();
            if(user == null)
            {
                throw new NotFoundException("Tài khoản không tồn tại");
            } else
            {
                var userDto = _mapper.Map<UserDto>(user);
                userDto.ImageFace = _mapper.Map<ImageFileDto>(user.ImageFace);
                userDto.ImageIdCardBefore = _mapper.Map<ImageFileDto>(user.ImageIdCardBefore);
                userDto.ImageIdCardAfter = _mapper.Map<ImageFileDto>(user.ImageIdCardAfter);
                userDto.Address = _unitOfWork.Wards.GetAddress((int)user.WardId);
                return userDto;
            }
        }

        public async Task<string> Login(UserLoginDto userLoginDto)
        {
            var user = await _unitOfWork.Users.Login(userLoginDto.Email, userLoginDto.Password);
            if(user == null)
            {
                throw new NotFoundException("Email hoặc mật khẩu không chính xác");
            }          

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Sid, user.Id + ""),
                    new Claim(ClaimTypes.Role, user.Role.Name + "")
                }),
                Expires = DateTime.UtcNow.AddHours(3),
                Issuer = _configuration["JwtSettings:Issuer"],
                Audience = _configuration["JwtSettings:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }

        public async Task UpdatePassword(UserPassworDto userPassworDto)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userPassworDto.Id);
            if (user == null)
            {
                throw new NotFoundException($"Không tìm thấy người dùng có id: {userPassworDto.Id}");
            } else if(user.Password.CompareTo(userPassworDto.OldPassword) != 0)
            {
                throw new BadRequestException($"Mật khẩu cũ không chính xác");
            }
            else
            {
                user.Password = userPassworDto.NewPassword;
                await _unitOfWork.Users.UpdateAsync(user);
                await _unitOfWork.SaveChangeAsync();
            }
        }

        public async Task UpdateRole(UserRoleUpdateDto userRoleUpdateDto)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userRoleUpdateDto.Id);
            if (user == null)
            {
                throw new NotFoundException($"Không tìm thấy người dùng có id: {userRoleUpdateDto.Id}");
            }
            else
            {
                var roleId = await _unitOfWork.Roles.GetIdByName(userRoleUpdateDto.RoleName);
                if(roleId != Guid.Empty)
                {
                    user.RoleId = roleId;
                    await _unitOfWork.Users.UpdateAsync(user);
                    await _unitOfWork.SaveChangeAsync();
                }
            }
        }

        public async Task<List<GetAllUserDto>> GetByEmail(string email)
        {
            var user = await _unitOfWork.Users.FindAsync(x => x.Email.Contains(email));
            var getAllUser = _mapper.Map<List<GetAllUserDto>>(user);
            return getAllUser;
        }
    }
}
