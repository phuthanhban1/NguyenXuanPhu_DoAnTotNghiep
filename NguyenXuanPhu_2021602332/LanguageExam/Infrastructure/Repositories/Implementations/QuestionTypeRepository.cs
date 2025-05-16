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
    public class QuestionTypeRepository : GenericRepository<QuestionType>, IQuestionTypeRepository
    {
        public QuestionTypeRepository(ExamContext context) : base(context)
        {
        }

        public async Task<bool> CheckNameBySkillId(Guid id, string name)
        {
             
            var check = _context.QuestionType.FirstOrDefault(x => x.Name == name && x.SkillId == id);
            return check != null;
        }

        public async Task<List<QuestionType>> GetsBySkillId(Guid skillId)
        {
            var list = _context.Set<QuestionType>()
                .Include(x => x.Skill)
                .Include(x => x.ContentBlocks)
                .Where(x => x.SkillId == skillId).ToList();
            return list;
        }

        public async Task<List<QuestionType>> GetsBySkillIdName(Guid skillId, string name)
        {
            var list = _context.Set<QuestionType>()
                .Include(x => x.Skill)
                .Include(x => x.ContentBlocks)
                .Where(x => x.SkillId == skillId && x.Name == name).ToList();
            return list;
        }

    }
}
