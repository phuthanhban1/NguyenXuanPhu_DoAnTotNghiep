﻿using Application.Dtos.QuestionTypeDtos;
using Domain.Entities;

namespace Application.Services.Interfaces
{
    public interface IQuestionTypeService
    {
        Task AddAsync(QuestionTypeCreateDto questionLevelCreateDto);
        Task UpdateAsync(QuestionTypeUpdateDto questionLevelUpdateDto);
        Task DeleteAsync(Guid id);
        Task<QuestionTypeUpdateDto> GetByIdAsync(Guid id);
        Task<List<QuestionType>> GetAllAsync();
        Task<List<QuestionTypeDto>> GetsBySkillId(Guid skillId);
        Task<List<QuestionTypeCountDto>> CountQuestionType(Guid skillId);
        Task<List<QuestionTypeCountDto>> CountQuestionTypePending(Guid skillId);

        Task<List<QuestionTypeCountDto>> CountQuestionType2(Guid skillId, Guid structId);
    }
}
