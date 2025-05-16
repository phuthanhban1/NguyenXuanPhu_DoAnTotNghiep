using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IQuestionBankRepository : IGenericRepository<QuestionBank>
    {
        Task<IEnumerable<QuestionBank>> GetByLanguageManager(string language, Guid managerId);
        Task<bool> FindByName(string language, string name);
    }
}
