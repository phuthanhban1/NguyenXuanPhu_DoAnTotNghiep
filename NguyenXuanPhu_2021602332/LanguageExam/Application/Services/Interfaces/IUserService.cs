﻿using Application.Dtos.UserDtos;

namespace Application.Services.Interfaces
{
    public interface IUserService
    {
        Task AddAsync(UserCreateDto userCreateDto);
        Task UpdateAsync(UserUpdateDto userUpdateDto);
        
        UserDto GetById(Guid id);
        Task<List<GetAllUserDto>> GetAllAsync();

        Task UpdateRole(UserRoleUpdateDto userRoleUpdateDto);
        Task UpdatePassword(UserPasswordDto userPasswordDto);

        Task<string> Login(UserLoginDto userLoginDto);
        Task<List<GetAllUserDto>> GetByEmail(string email);
        Task<bool> CheckUserByEmail(string email);
        Task<List<GetAllUserDto>> GetAccounts(Guid id);
        Task<List<UserDto>> GetUserByRole(int roleNumber);

        Task<UserDto> GetUser(Guid id);
        Task<bool> CheckFullInfor(Guid id);


    }
}
