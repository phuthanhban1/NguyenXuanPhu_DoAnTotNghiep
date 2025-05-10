using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IQuestionTypeRepository : IGenericRepository<QuestionType>
    {
        Task<List<QuestionType>> GetsBySkillId(Guid skillId);
        Task<bool> CheckNameBySkillId(Guid id, string name);
    }
}
