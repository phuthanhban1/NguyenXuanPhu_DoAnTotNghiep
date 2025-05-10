using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interfaces
{
    public interface ISkillRepository : IGenericRepository<Skill>
    {
        Skill GetByCreate(Guid id);
        Skill GetByReview(Guid id);
        Task ConfirmSkill(Skill skill);
        Task<Skill> GetSkillByCreate(Guid id);
        Task<Skill> GetSkillByReview(Guid id);
        Task<List<Skill>> GetSkillsByBankId(Guid id);
    }
}
