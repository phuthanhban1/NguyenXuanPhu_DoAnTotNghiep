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
    public class ExamQuestionRepository : GenericRepository<ExamQuestion>, IExamQuestionRepository
    {
        public ExamQuestionRepository(ExamContext context) : base(context)
        {
        }
    }
}
