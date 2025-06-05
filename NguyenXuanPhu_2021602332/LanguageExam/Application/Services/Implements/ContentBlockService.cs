using Application.Dtos.ContentBlockDtos;
using Application.Dtos.QuestionDtos;
using Application.Dtos.SimilarQuestions;
using Application.Exceptions;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
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
        public async Task Add(List<ContentBlockCreateDto> list)
        {
            var listNewContent = new List<ContentBlock>();
            foreach (var contentBlockCreateDto in list)
            {
                var contentBlock = new ContentBlock
                {
                    Id = Guid.NewGuid(),
                    Content = contentBlockCreateDto.Content,
                    QuestionTypeId = contentBlockCreateDto.QuestionTypeId,
                    Status = 0,
                };
                var audioFile = new ExamFile();
                var imageFile = new ExamFile();
                if (contentBlockCreateDto.AudioFile != null)
                {
                    audioFile = await ExtensionService.GetImageFile(contentBlockCreateDto.AudioFile);
                    await _unitOfWork.ExamFiles.AddAsync(audioFile);
                    contentBlock.AudioFileId = audioFile.Id;
                }
                if (contentBlockCreateDto.ImageFile != null)
                {
                    imageFile = await ExtensionService.GetImageFile(contentBlockCreateDto.ImageFile);
                    await _unitOfWork.ExamFiles.AddAsync(imageFile);
                    contentBlock.ImageFileId = imageFile.Id;
                }
                listNewContent.Add(contentBlock);
                await _unitOfWork.ContentBlocks.AddAsync(contentBlock);
                contentBlockCreateDto.Questions.ForEach(async (x) =>
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
            if (listNewContent[0].AudioFile == null && listNewContent[0].Content != null)
            {
                var listContents = await _unitOfWork.ContentBlocks.GetByQuestionTypeId(list[0].QuestionTypeId);
                var listOldContents = _mapper.Map<List<ContentBlockSimilarDto>>(listContents);
                var listNewContents = _mapper.Map<List<ContentBlockSimilarDto>>(listNewContent);
                var listSimilar = await ExtensionService.SimilarCheck(listOldContents, listNewContents);
                listSimilar.ForEach(async (l) => { await _unitOfWork.SimilarQuestions.AddAsync(l); });
            }
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<List<ContentBlockDto>> GetByStatus(Guid questionTypeId, byte status)
        {
            var list = await _unitOfWork.ContentBlocks.GetByStatus(questionTypeId, status);
            var contentBlockDtos = _mapper.Map<List<ContentBlockDto>>(list);
            foreach(var c in contentBlockDtos)
            {
                var listSimilars = await _unitOfWork.SimilarQuestions.GetSimilarQuestions(c.Id);
                var listSimilarDtos = _mapper.Map<List<SimilarQuestionDto>>(listSimilars);
                foreach (var similarQuestion in listSimilarDtos)
                {
                    var contentBlock = await _unitOfWork.ContentBlocks.GetContentBlockByIdAsync(similarQuestion.Id);
                    _mapper.Map(contentBlock, similarQuestion);
                }
                c.SimilarQuestions = listSimilarDtos;
            }
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
            var listSimilar = await _unitOfWork.SimilarQuestions.GetSimilarQuestionsById(id);
            listSimilar.ForEach(async (s) =>
            {
                await _unitOfWork.SimilarQuestions.DeleteAsync(s);
            });
            await _unitOfWork.ContentBlocks.DeleteAsync(contentBlock);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task ChangeStatus(ContentBlockStatusDto contentBlockStatusDto)
        {
            await _unitOfWork.ContentBlocks.ChangeStatus(contentBlockStatusDto.Id, contentBlockStatusDto.Status);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<string> GetQuestionTypeName(Guid id)
        {
            var contentBlock = _unitOfWork.ContentBlocks.GetById(id).Include(c => c.QuestionType).ToList()[0];
            return contentBlock.QuestionType.Name;
        }

        public async Task Approve(Guid contentBlockId)
        {
           var contentBlock = await _unitOfWork.ContentBlocks.GetByIdAsync(contentBlockId);
            if (contentBlock == null)
            {
                throw new NotFoundException("ContentBlock not found");
            }
            contentBlock.Status = 1;
            await _unitOfWork.ContentBlocks.UpdateAsync(contentBlock);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task Reject(ContentBlockRejectDto contentBlockRejectDto)
        {
            var contentBlock = await _unitOfWork.ContentBlocks.GetByIdAsync(contentBlockRejectDto.Id);
            if (contentBlock == null)
            {
                throw new NotFoundException("ContentBlock not found");
            }
            contentBlock.RejectionReason = contentBlockRejectDto.RejectionReason;
            contentBlock.Status = 2;
            await _unitOfWork.ContentBlocks.UpdateAsync(contentBlock);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task Update(ContentBlockUpdateDto contentBlockUpdateDto)
        {
            var contentBlock = _unitOfWork.ContentBlocks.GetById(contentBlockUpdateDto.Id)
                .Include(c => c.Questions)
                .ThenInclude(q => q.Answers)
                .ToList()[0];
            
            var audioFile = new ExamFile();
            var imageFile = new ExamFile();
            if (contentBlockUpdateDto.AudioFile != null)
            {
                audioFile = await ExtensionService.GetImageFile(contentBlockUpdateDto.AudioFile);
                audioFile.Id = (Guid)contentBlock.AudioFileId;
                await _unitOfWork.ExamFiles.UpdateAsync(audioFile);
            }
            if (contentBlockUpdateDto.ImageFile != null)
            {
                imageFile = await ExtensionService.GetImageFile(contentBlockUpdateDto.ImageFile);
                imageFile.Id = (Guid)contentBlock.ImageFileId;
                await _unitOfWork.ExamFiles.AddAsync(imageFile);
            }
            contentBlock.Content = contentBlockUpdateDto.Content;
            await _unitOfWork.ContentBlocks.UpdateAsync(contentBlock);
            foreach (var q in contentBlock.Questions)
            {
                await _unitOfWork.Questions.DeleteAsync(q);
            }
            contentBlockUpdateDto.Questions.ForEach(async (x) =>
            {
                var question = new Question
                {
                    Id = new Guid(),
                    Content = x.Content,
                    Score = x.Score,
                    ContentBlockId = contentBlock.Id
                };
                await _unitOfWork.Questions.AddAsync(question);
                x.Answers.ForEach(async (a) =>
                {
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
            await _unitOfWork.SaveChangeAsync();
        }
    }
    
}
