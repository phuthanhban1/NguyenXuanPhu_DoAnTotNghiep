using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IExamStructDetailRepository : IGenericRepository<ExamStructDetail>
    {
        Task<List<ExamStructDetail>> GetByExamStructId(Guid id, string skill);
        Task DeleteByStructId(Guid id);
    }
}
