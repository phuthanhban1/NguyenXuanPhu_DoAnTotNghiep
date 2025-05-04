using Application.Dtos.QuestionTypeDtos;

namespace Application.Services.Interfaces
{
    public interface IQuestionTypeService
    {
        Task AddAsync(QuestionTypeCreateDto questionLevelCreateDto);
        Task UpdateAsync(QuestionTypeUpdateDto questionLevelUpdateDto);
        Task DeleteAsync(Guid id);
        Task<QuestionTypeUpdateDto> GetByIdAsync(Guid id);
        Task<List<QuestionTypeUpdateDto>> GetAllAsync(Guid skillId);
        Task<List<QuestionTypeDto>> GetsBySkillId(Guid skillId);
    }
}
