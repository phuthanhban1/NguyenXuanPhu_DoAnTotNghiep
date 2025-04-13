using Application.Dtos.AnswerDtos;
using Domain.Entities;

namespace Application.Services.Interfaces
{
    public interface IAnswerService 
    {
        Task AddAsync(AnswerCreateDto answerCreateDto, Guid questionId);
        Task UpdateAsync(AnswerDto answerDto);
        Task DeleteAsync(Guid id);
        Task<Answer> GetByIdAsync(Guid id);
        IEnumerable<Answer> GetAllAsync();
    }
}
