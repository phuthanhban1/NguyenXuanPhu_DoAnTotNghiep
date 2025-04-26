using Application.Dtos.ImageFileDtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IImageFileService
    {
        Task<Guid> AddAsync(IFormFile file);
        Task UpdateAsync(Guid id, IFormFile file);
        Task DeleteAsync(Guid id);
        Task<ImageFileDto> GetByIdAsync(Guid id);
        Task<List<ImageFileDto>> GetAllAsync();


    }
}
