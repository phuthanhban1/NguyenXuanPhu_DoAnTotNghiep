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
    public class ExamRepository : GenericRepository<Exam>, IExamRepository
    {
        public ExamRepository(ExamContext context) : base(context)
        {
        }

        public async Task<bool> CheckDate(DateTime date)
        {
            var exam = _context.Set<Exam>().FirstOrDefault(x => x.StartDate.Date == date.Date);
            if (exam != null) return true;
            return false;
        }

        public async Task<Exam> GetExamByCreate(Guid id)
        {
            var exam = _context.Set<Exam>().FirstOrDefault(x => x.CreatedQuestionUserId == id && x.IsCreated == false);
            return exam;
        }

        public async Task<List<Exam>> GetExamHasResult()
        {
            var thirtyDaysAgo = DateTime.Now.Date.AddDays(-30);
            var list = _context.Set<Exam>().Where(x => x.StartDate.Date <= thirtyDaysAgo).ToList();
            return list;
        }
    }
}
