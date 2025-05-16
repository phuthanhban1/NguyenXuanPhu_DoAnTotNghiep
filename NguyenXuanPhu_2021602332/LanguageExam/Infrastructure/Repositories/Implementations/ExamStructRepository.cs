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
    public class ExamStructRepository : GenericRepository<ExamStruct>, IExamStructRepository
    {
        public ExamStructRepository(ExamContext context) : base(context)
        {
        }

        public async Task<List<ExamStruct>> GetListsByBankId(Guid id)
        {
            var list = _context.Set<ExamStruct>().Where(e => e.QuestionBankId == id).ToList();
            return list;
        }
    }
}
