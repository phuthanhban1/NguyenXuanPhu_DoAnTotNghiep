using Application.Dtos.QuestionTypeDtos;
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
    }
}
