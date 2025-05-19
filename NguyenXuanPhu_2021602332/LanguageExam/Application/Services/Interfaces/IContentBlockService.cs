using Application.Dtos.ContentBlockDtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IContentBlockService
    {
        IEnumerable<ContentBlock> GetAllAsync();
        Task<ContentBlock> GetByIdAsync(Guid id);
        Task AddDouble(List<ContentBlockDoubleDto> contentBlockDoubleDto);
        Task AddSingle(List<ContentBlockSingleDto> list);
        Task DeleteAsync(Guid id);
        //Task UpdateAsync(ContentBlockUpdateDto contentBlockUpdateDto);
        Task<List<ContentBlockDto>> GetByStatus(Guid questionTypeId, byte status);
        Task ChangeStatus(ContentBlockStatusDto contentBlockStatusDto);
    }
}
