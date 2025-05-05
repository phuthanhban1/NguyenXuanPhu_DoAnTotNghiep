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
        Task AddSingleText(ContentBlockSingleTextDto contentBlockSingleTextDto);
        Task AddSingle(ContentBlockSingleFileDto contentBlockSingleFileDto);
        //Task DeleteAsync(Guid id);
        //Task UpdateAsync(ContentBlockUpdateDto contentBlockUpdateDto);
    }
}
