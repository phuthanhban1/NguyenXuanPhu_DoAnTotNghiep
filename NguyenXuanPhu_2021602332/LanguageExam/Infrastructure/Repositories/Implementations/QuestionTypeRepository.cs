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
    public class QuestionTypeRepository : GenericRepository<QuestionType>, IQuestionTypeRepository
    {
        public QuestionTypeRepository(ExamContext context) : base(context)
        {
        }

        public async Task<List<QuestionType>> GetsBySkillId(Guid skillId)
        {
            var list = _context.Set<QuestionType>().Where(x => x.SkillId == skillId).ToList();
            return list;
        }
    }
}
