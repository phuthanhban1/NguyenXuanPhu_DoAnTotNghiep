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
    public class SkillRepository : GenericRepository<Skill>, ISkillRepository
    {
        public SkillRepository(ExamContext context) : base(context)
        {
        }

        public Task ConfirmSkill(Skill skill)
        {
            _context.Entry(skill).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public Skill GetByCreate(Guid id)
        {
            var skill = _context.Set<Skill>()
                .Include(x => x.QuestionBank)
                .FirstOrDefault(x => x.CreatedUserId == id && x.IsProcess == true);
            return skill;
        }

        public Skill GetByReview(Guid id)
        {
            var skill = _context.Set<Skill>()
                .Include(x => x.QuestionBank)
                .FirstOrDefault(x => x.ReviewedUserId == id && x.IsProcess == true);
            return skill;
        }

        public async Task<Skill> GetSkillByCreate(Guid id)
        {
            var skill = _context.Set<Skill>()
                .Include(x => x.QuestionBank)
                .FirstOrDefault(x => x.CreatedUserId == id && x.IsProcess == true);
            return skill;
        }

        public async Task<Skill> GetSkillByReview(Guid id)
        {
            Skill skill = _context.Set<Skill>()
                .Include(x => x.QuestionBank)
                .FirstOrDefault(x => x.ReviewedUserId == id && x.IsProcess == true);
            return skill;
        }
    }
}
