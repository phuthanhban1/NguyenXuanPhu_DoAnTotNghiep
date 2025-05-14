using Application.Dtos.ContentBlockDtos;
using Application.Dtos.QuestionDtos;
using Application.Exceptions;
using Application.Services.Interfaces;
using AutoMapper;
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
        private readonly IMapper _mapper;
        public ContentBlockService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddDouble(List<ContentBlockDoubleDto> list)
        {
            foreach(var contentBlockDoubleDto in list)
            {
                var contentBlock = new ContentBlock
                {
                    Id = Guid.NewGuid(),
                    Content = contentBlockDoubleDto.Content,
                    Level = contentBlockDoubleDto.Level,
                    QuestionTypeId = contentBlockDoubleDto.QuestionTypeId,
                    Status = 0,
                    IsUsed = false,
                    CreatedDate = DateOnly.FromDateTime(DateTime.UtcNow),
                    UpdatedDate = DateOnly.FromDateTime(DateTime.UtcNow),
                };
                var audioFile = new ExamFile();
                var imageFile = new ExamFile();
                if (contentBlockDoubleDto.AudioFile != null)
                {
                    audioFile = await ExtensionService.GetImageFile(contentBlockDoubleDto.AudioFile);
                    await _unitOfWork.ExamFiles.AddAsync(audioFile);
                    contentBlock.AudioFileId = audioFile.Id;
                }
                if (contentBlockDoubleDto.ImageFile != null)
                {
                    imageFile = await ExtensionService.GetImageFile(contentBlockDoubleDto.ImageFile);
                    await _unitOfWork.ExamFiles.AddAsync(imageFile);
                    contentBlock.ImageFileId = imageFile.Id;
                }
                await _unitOfWork.ContentBlocks.AddAsync(contentBlock);
                contentBlockDoubleDto.Questions.ForEach(async (x) =>
                {
                    var question = new Question
                    {
                        Id = new Guid(),
                        Content = x.Content,
                        Score = x.Score,
                        ContentBlockId = contentBlock.Id
                    };
                    await _unitOfWork.Questions.AddAsync(question);
                    x.Answers.ForEach(async (a) => {
                        var count = 0;
                        var answerEntity = new Answer
                        {
                            Id = Guid.NewGuid(),
                            QuestionId = question.Id,
                            Content = a.Content,
                            IsCorrect = a.IsCorrect
                        };
                        if ((bool)a.IsCorrect) count++;
                        if (count > 1)
                            throw new BadRequestException("Có nhiều hơn 1 đáp án đúng");
                        await _unitOfWork.Answers.AddAsync(answerEntity);
                    });
                });
            }
            await _unitOfWork.SaveChangeAsync();
        }
        public Task<ContentBlock> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<ContentBlock> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task AddSingle(List<ContentBlockSingleDto> list)
        {
            foreach (var contentBlockSingleDto in list)
            {
                var contentBlock = new ContentBlock
                {
                    Id = Guid.NewGuid(),
                    Content = contentBlockSingleDto.TextContent,
                    Level = contentBlockSingleDto.Level,
                    QuestionTypeId = contentBlockSingleDto.QuestionTypeId,
                    Status = 0,
                    IsUsed = false,
                    CreatedDate = DateOnly.FromDateTime(DateTime.UtcNow),
                    UpdatedDate = DateOnly.FromDateTime(DateTime.UtcNow),
                };
                var audioFile = new ExamFile();
                var imageFile = new ExamFile();
                if (contentBlockSingleDto.AudioFile != null)
                {
                    audioFile = await ExtensionService.GetImageFile(contentBlockSingleDto.AudioFile);
                    await _unitOfWork.ExamFiles.AddAsync(audioFile);
                    contentBlock.AudioFileId = audioFile.Id;
                }
                if (contentBlockSingleDto.ImageFile != null)
                {
                    imageFile = await ExtensionService.GetImageFile(contentBlockSingleDto.ImageFile);
                    await _unitOfWork.ExamFiles.AddAsync(imageFile);
                    contentBlock.ImageFileId = imageFile.Id;
                }


                await _unitOfWork.ContentBlocks.AddAsync(contentBlock);
                var question = new Question
                {
                    Id = Guid.NewGuid(),
                    ContentBlockId = contentBlock.Id,
                    Score = contentBlockSingleDto.Score
                };
                await _unitOfWork.Questions.AddAsync(question);
                byte count = 0;
                foreach (var answer in contentBlockSingleDto.Answers)
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
            }
            
            await _unitOfWork.SaveChangeAsync();
        }


        public async Task<List<ContentBlockDto>> GetByStatus(Guid questionTypeId, byte status)
        {
            var list = await _unitOfWork.ContentBlocks.GetByStatus(questionTypeId, status);
            var contentBlockDtos = _mapper.Map<List<ContentBlockDto>>(list);
            return contentBlockDtos;
        }

        public async Task DeleteAsync(Guid id)
        {
            var contentBlock = await _unitOfWork.ContentBlocks.GetByIdAsync(id);
            if(contentBlock.ImageFileId != null)
            {
                var image = await _unitOfWork.ExamFiles.GetByIdAsync((Guid)contentBlock.ImageFileId);
                _unitOfWork.ExamFiles.DeleteAsync(image);
            }
            if (contentBlock.AudioFileId != null)
            {
                var audio = await _unitOfWork.ExamFiles.GetByIdAsync((Guid)contentBlock.AudioFileId);
                _unitOfWork.ExamFiles.DeleteAsync(audio);
            }

            await _unitOfWork.ContentBlocks.DeleteAsync(contentBlock);
            await _unitOfWork.SaveChangeAsync();
        }
        public Task UpdateAsync(ContentBlockUpdateDto contentBlockUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
    
}
