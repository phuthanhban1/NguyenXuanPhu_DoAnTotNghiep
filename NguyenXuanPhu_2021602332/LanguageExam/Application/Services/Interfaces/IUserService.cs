using Application.Dtos.UserDtos;

namespace Application.Services.Interfaces
{
    public interface IUserService
    {
        Task AddAsync(UserCreateDto userCreateDto);
        Task UpdateAsync(UserUpdateDto userUpdateDto);
        Task DeleteAsync(Guid id);
        Task<UserDto> GetByIdAsync(Guid id);
        Task<List<UserDto>> GetAllAsync();

        Task UpdateRole(UserRoleUpdateDto userRoleUpdateDto);
        Task UpdatePassword(UserPassworDto userPassworDto);
    }
}
