using Application.Dtos.ContentBlockDtos;
using Application.Exceptions;
using Application.Services.Interfaces;
using Domain.Entities;
using Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implements
{
    public class ContentBlockService : IContentBlockService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContentBlockService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddSingleText(ContentBlockSingleTextDto contentBlockSingleTextDto)
        {
            var contentBlock = new ContentBlock
            {
                Id = Guid.NewGuid(),
                TextContent = contentBlockSingleTextDto.TextContent,
                Level = contentBlockSingleTextDto.Level,
                QuestionTypeId = contentBlockSingleTextDto.QuestionTypeId,
                IsConfirm = false,
                IsUsed = false,
                CreatedDate = DateOnly.FromDateTime(DateTime.UtcNow),
                UpdatedDate = DateOnly.FromDateTime(DateTime.UtcNow),
            };
            await _unitOfWork.ContentBlocks.AddAsync(contentBlock);
            var question = new Question
            {
                Id = Guid.NewGuid(),
                ContentBlockId = contentBlock.Id,
                Score = contentBlockSingleTextDto.Score
            };
            await _unitOfWork.Questions.AddAsync(question);
            foreach (var answer in contentBlockSingleTextDto.Answers)
            {
                var answerEntity = new Answer
                {
                    Id = Guid.NewGuid(),
                    QuestionId = question.Id,
                    Content = answer.Content,
                    IsCorrect = answer.IsCorrect
                };
                await _unitOfWork.Answers.AddAsync(answerEntity);
            }
            await _unitOfWork.SaveChangeAsync();

        }
        //public bool IsConfirm { get; set; }
        //public bool IsUsed { get; set; }
        //public DateOnly CreatedDate { get; set; }
        //public DateOnly? UpdatedDate { get; set; }
        //public string? RejectionReason { get; set; }
        public Task<ContentBlock> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<ContentBlock> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task AddSingle(ContentBlockSingleFileDto contentBlockSingleFileDto)
        {
            var contentBlock = new ContentBlock
            {
                Id = Guid.NewGuid(),
                TextContent = contentBlockSingleFileDto.TextContent,
                Level = contentBlockSingleFileDto.Level,
                QuestionTypeId = contentBlockSingleFileDto.QuestionTypeId,
                IsConfirm = false,
                IsUsed = false,
                CreatedDate = DateOnly.FromDateTime(DateTime.UtcNow),
                UpdatedDate = DateOnly.FromDateTime(DateTime.UtcNow),
            };
            var audioFile = new ExamFile();
            var imageFile = new ExamFile();
            if (contentBlockSingleFileDto.AudioFile != null)
            {
                audioFile = await ExtensionService.GetImageFile(contentBlockSingleFileDto.AudioFile);
                await _unitOfWork.ExamFiles.AddAsync(audioFile);
                contentBlock.AudioFileId = audioFile.Id;
            }
            if (contentBlockSingleFileDto.ImageFile != null)
            {
                imageFile = await ExtensionService.GetImageFile(contentBlockSingleFileDto.ImageFile);
                await _unitOfWork.ExamFiles.AddAsync(imageFile);
                contentBlock.ImageFileId = imageFile.Id;
            }
            
            
            await _unitOfWork.ContentBlocks.AddAsync(contentBlock);
            var question = new Question
            {
                Id = Guid.NewGuid(),
                ContentBlockId = contentBlock.Id,
                Score = contentBlockSingleFileDto.Score
            };
            await _unitOfWork.Questions.AddAsync(question);
            byte count = 0;
            foreach (var answer in contentBlockSingleFileDto.Answers)
            {
                var answerEntity = new Answer
                {
                    Id = Guid.NewGuid(),
                    QuestionId = question.Id,
                    Content = answer.Content,
                    IsCorrect = answer.IsCorrect
                };
                if (answer.IsCorrect) count++;
                if (count > 1)
                    throw new BadRequestException("Có nhiều hơn 1 đáp án đúng");
                await _unitOfWork.Answers.AddAsync(answerEntity);
            }
            await _unitOfWork.SaveChangeAsync();
        }
        //public Task DeleteAsync(Guid id)
        //{
        //    throw new NotImplementedException();
        //}
        //public Task UpdateAsync(ContentBlockUpdateDto contentBlockUpdateDto)
        //{
        //    throw new NotImplementedException();
        //}
    }
    
}
