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

        public async Task<Examinee> GetExamineeByNumber(Guid examId, string examineeNumber)
        {
            var examinee = await _context.Set<Examinee>()
                .Include(e => e.User)
                .Include(e => e.Exam)
                .FirstOrDefaultAsync(e => e.ExamId == examId && e.ExamineeNumber == examineeNumber);
            return examinee;
        }

        public async Task<List<Examinee>> GetExamineesByExamId(Guid examId)
        {
            var examinees = _context.Set<Examinee>()
                .Include(e => e.Room)
                .Include(e => e.User)
                .Include(e => e.Exam)
                .Where(e => e.ExamId == examId).ToList();
            return examinees;
        }

        public async Task<List<Examinee>> GetExamineesByUserId(Guid userId)
        {
            var examinees = _context.Set<Examinee>()
                .Include(e => e.Room)
                .Where(e => e.UserId == userId).ToList();
            return examinees;
        }
    }
}
