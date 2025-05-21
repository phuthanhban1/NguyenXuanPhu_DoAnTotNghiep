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
    public class DetailResultRepository : GenericRepository<DetailResult>, IDetailResultRepository
    {
        public DetailResultRepository(ExamContext context) : base(context)
        {
        }

        public async Task<List<DetailResult>> GetDetailResultsByExamUser(Guid examId, Guid userId)
        {
            var detailResults = _context.DetailResult
                .Where(x => x.ExamId == examId && x.UserId == userId)
                .ToList();
            return detailResults;
        }
    }
}
