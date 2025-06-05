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
        Task Update(ContentBlockUpdateDto contentBlockUpdateDto);
        Task Add(List<ContentBlockCreateDto> contentBlockDoubleDto);
        
        Task DeleteAsync(Guid id);
       
        Task<List<ContentBlockDto>> GetByStatus(Guid questionTypeId, byte status);
        Task ChangeStatus(ContentBlockStatusDto contentBlockStatusDto);
        Task<string> GetQuestionTypeName(Guid id);

        Task Approve(Guid contentBlockId);
        Task Reject(ContentBlockRejectDto contentBlockRejectDto);

        
    }
}
