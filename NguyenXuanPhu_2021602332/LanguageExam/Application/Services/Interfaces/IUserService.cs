using Application.Dtos.UserDtos;

namespace Application.Services.Interfaces
{
    public interface IUserService
    {
        Task AddAsync(UserCreateDto userCreateDto);
        Task UpdateAsync(UserUpdateDto userUpdateDto);
        
        UserDto GetById(Guid id);
        Task<List<GetAllUserDto>> GetAllAsync();

        Task UpdateRole(UserRoleUpdateDto userRoleUpdateDto);
        Task UpdatePassword(UserPassworDto userPassworDto);

        Task<string> Login(UserLoginDto userLoginDto);
        Task<List<GetAllUserDto>> GetByEmail(string email);
    }
}
