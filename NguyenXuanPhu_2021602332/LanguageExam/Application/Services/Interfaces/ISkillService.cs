using Application.Dtos.QuestionBankDtos;
using Application.Dtos.SkillDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface ISkillService
    {
        Task AddAsync(SkillCreateDto skillDto);
        Task UpdateAsync(SkillUpdateDto skillDto);
        Task DeleteAsync(Guid id);
        Task<QuestionBankDto> GetByIdAsync(Guid id);
        Task<List<SkillDto>> GetByQuestionBankIdAsync(Guid questionBankId);
    }
}
