using Application.Dtos.ExamStructDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IExamStructDetailService
    {
        Task<List<ExamStructDetailDto>> GetStruct(Guid id, string skill);
        Task Add(List<ExamStructDetailCreateDto> list);
    }
}
