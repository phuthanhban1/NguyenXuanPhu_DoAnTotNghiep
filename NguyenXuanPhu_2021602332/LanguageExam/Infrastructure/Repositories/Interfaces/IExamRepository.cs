using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IExamRepository : IGenericRepository<Exam>
    {
        Task<Exam> GetExamByCreate(Guid id);
        Task<List<Exam>> GetExamHasResult();
        Task<bool> CheckDate(DateTime date);
    }
}
