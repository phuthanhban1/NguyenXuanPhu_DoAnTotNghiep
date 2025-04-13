using Application.Dtos.ExamineeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IExamineeService
    {
        Task AddAsync(ExamineeCreateDto examineeCreateDto);
        Task UpdateAsync(ExamineeUpdateDto examineeUpdateDto);
        Task DeleteAsync(Guid id);
        //Task<ExamineeDto> GetByIdAsync(Guid id);
        //Task<List<ExamineeDto>> GetAllAsync();
    }
}
