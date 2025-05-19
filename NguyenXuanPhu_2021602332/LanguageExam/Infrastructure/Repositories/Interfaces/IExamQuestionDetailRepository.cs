using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IExamQuestionDetailRepository : IGenericRepository<ExamQuestionDetail>
    {
        Task<List<ExamQuestionDetail>> GetAllByExamQuestionId( Guid id);
    }
}
