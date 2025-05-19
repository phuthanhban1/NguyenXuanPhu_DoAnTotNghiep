using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Implementations
{
    public class ExamQuestionDetailRepository : GenericRepository<ExamQuestionDetail>, IExamQuestionDetailRepository
    {
        public ExamQuestionDetailRepository(ExamContext context) : base(context)
        {
        }

        public async Task<List<ExamQuestionDetail>> GetAllByExamQuestionId(Guid id)
        {
            var list = _context.ExamQuestionDetails.Where(e => e.ExamQuestionId == id).ToList();
            return list;
        }
    }
}
