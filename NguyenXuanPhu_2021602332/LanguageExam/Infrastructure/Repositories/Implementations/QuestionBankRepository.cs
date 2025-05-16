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
    public class QuestionBankRepository : GenericRepository<QuestionBank>, IQuestionBankRepository
    {
        public QuestionBankRepository(ExamContext context) : base(context)
        {
        }

        public async Task<bool> FindByName(string language, string name)
        {
            var qb = await _context.Set<QuestionBank>().FirstOrDefaultAsync(q => q.Language == language && q.Name == name);
            if(qb != null)
            {
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<QuestionBank>> GetByLanguageManager(string language, Guid managerId)
        {
            var list = await _context.Set<QuestionBank>().Where(q => q.Language == language && q.ManagerId == managerId).ToListAsync();
            return list;
        }
    }
}
