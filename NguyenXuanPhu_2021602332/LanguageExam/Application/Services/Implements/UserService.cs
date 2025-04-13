using Application.Dtos.UserDtos;
using Application.Exceptions;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.UnitOfWork;

namespace Application.Services.Implements
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(UserCreateDto userCreateDto)
        {
            var user = _mapper.Map<User>(userCreateDto);
            user.Id = Guid.NewGuid();
            user.RoleId = new Guid("23AD4800-5D72-4944-BEA4-A65FEED901D5");  
            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveChangeAsync();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(UserUpdateDto userUpdateDto)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userUpdateDto.Id);
            if(user == null)
            {
                throw new NotFoundException($"Không tìm thấy người dùng có id: {userUpdateDto.Id}");
            }
            else
            {
                _mapper.Map(userUpdateDto, user);
                await _unitOfWork.Users.UpdateAsync(user);
                await _unitOfWork.SaveChangeAsync();
            }
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
    }
}
