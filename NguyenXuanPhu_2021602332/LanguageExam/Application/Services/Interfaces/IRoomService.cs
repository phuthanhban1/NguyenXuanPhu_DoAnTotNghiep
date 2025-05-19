using Application.Dtos.RoomDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IRoomService
    {
        Task<List<RoomDto>> GetAllAsync();
        Task<RoomDto> GetByIdAsync(Guid id);
        Task AddAsync(RoomCreateDto roomDto);
        Task UpdateAsync(RoomDto roomDto);
        Task DeleteAsync(Guid id);
    }
}
