using Application.Dtos.ImageFileDtos;
using Application.Exceptions;
using Application.Services.Interfaces;
using Domain.Entities;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implements
{
    public class ImageFileService : IImageFileService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ImageFileService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task DeleteAsync(Guid id)
        {
            var image = await _unitOfWork.ImageFiles.GetByIdAsync(id);
            if (image == null)
            {
                throw new NotFoundException($"Không tìm thấy ảnh có id {id}");
            }
            else
            {
                await _unitOfWork.ImageFiles.DeleteAsync(image);
                await _unitOfWork.SaveChangeAsync();
            }
        }

        public Task<List<ImageFileDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ImageFileDto> GetByIdAsync(Guid id)
        {
            var image = await _unitOfWork.ImageFiles.GetByIdAsync(id);
            if (image == null)
            {
                return null;
            }
            return new ImageFileDto
            {
                Id = id,
                FileName = image.FileName,
                FileData = image.FileData,
                ContentType = image.ContentType
            };
        }
        public async Task UpdateAsync(Guid id, IFormFile file)
        {
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);

            var image = await _unitOfWork.ImageFiles.GetByIdAsync(id);
            if(image == null)
            {
                throw new NotFoundException($"Không tìm thấy ảnh có id {id}");
            } else
            {
                image.FileName = file.FileName;
                image.FileData = memoryStream.ToArray();
                image.ContentType = file.ContentType;
                await _unitOfWork.ImageFiles.UpdateAsync(image);
                await _unitOfWork.SaveChangeAsync();
            }
        }

        public async Task<Guid> AddAsync(IFormFile file)
        {
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            Guid idImage = Guid.NewGuid();
            var image = new Domain.Entities.File
            {
                Id = idImage,
                FileName = file.FileName,
                FileData = memoryStream.ToArray(),
                ContentType = file.ContentType
            };
            await _unitOfWork.ImageFiles.AddAsync(image);
            await _unitOfWork.SaveChangeAsync();
            return idImage;
        }
    }
}
