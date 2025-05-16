using Application.Dtos.ExamStruct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IExamStructService
    {
        Task Add(Guid userId, ExamStructCreateDto examStructCreateDto);
        Task<List<ExamStructDto>> GetListByBankId(Guid id);
        Task Delete(Guid id);
        Task Update(ExamStructUpdateDto examStructUpdateDto);

    }
}
