using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IExamQuestionRepository : IGenericRepository<ExamQuestion>
    {
        Task<ExamQuestion> GetByExamId(Guid id);
        Task<Guid> GetIdByExamId(Guid id);
    }
}
