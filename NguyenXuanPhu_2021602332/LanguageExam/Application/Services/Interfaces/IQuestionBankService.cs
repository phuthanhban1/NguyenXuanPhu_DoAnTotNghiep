using Application.Dtos.QuestionBankDtos;
using Application.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IQuestionBankService
    {
        Task AddAsync(QuestionBankCreateDto questionBankCreateDto, Guid managerId);
        Task UpdateAsync(QuestionBankUpdateDto questionBankUpdateDto);
        Task DeleteAsync(Guid id);
        Task<List<QuestionBankDto>> GetByLanguageManageId(string language, Guid managerId);
        Task<List<QuestionBankDto>> GetAllAsync();
        Task<QuestionBankDetailDto> GetDetail(Guid id);
    }
}
