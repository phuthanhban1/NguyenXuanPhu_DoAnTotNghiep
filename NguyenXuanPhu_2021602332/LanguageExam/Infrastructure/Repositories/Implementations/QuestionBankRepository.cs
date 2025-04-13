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
    public class QuestionBankRepository : GenericRepository<QuestionBank>, IQuestionBankRepository
    {
        public QuestionBankRepository(ExamContext context) : base(context)
        {
        }
    }
}
