using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Implementations
{
    public class ExamStructDetailRepository : GenericRepository<ExamStructDetail>, IExamStructDetailRepository
    {
        public ExamStructDetailRepository(ExamContext context) : base(context)
        {
        }

        public async Task DeleteByStructId(Guid id, string skillName)
        {
            var list = _context.ExamStructDetail.Where(e => e.ExamStructId == id && e.Skill == skillName).ToList();
            list.ForEach(l => DeleteAsync(l));
        }

        public async Task<List<ExamStructDetail>> GetAllByExamStructId(Guid id)
        {
            var list = _context.ExamStructDetail.Where(e => e.ExamStructId == id).ToList();
            return list;
        }

        public async Task<List<ExamStructDetail>> GetByExamStructId(Guid id, string skill)
        {
            var list = _context.ExamStructDetail
                .Include(e => e.QuestionType)
                .Where(e => e.ExamStructId == id && e.Skill == skill).ToList();
            return list;
        }
    }
}
