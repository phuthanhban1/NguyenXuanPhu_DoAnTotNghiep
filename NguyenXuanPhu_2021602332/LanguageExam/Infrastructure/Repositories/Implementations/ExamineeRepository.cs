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
    public class ExamineeRepository : GenericRepository<Examinee>, IExamineeRepository
    {
        public ExamineeRepository(ExamContext context) : base(context)
        {
        }

        public async Task<Examinee> GetByExamAndUserId(Guid examId, Guid userId)
        {
            return await _context.Set<Examinee>().Where(e => e.ExamId == examId && e.UserId == userId).FirstOrDefaultAsync();
        }
    }
}
