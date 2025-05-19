using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Implementations
{
    public class WardRepository : GenericRepository<Ward>, IWardRepository
    {
        public WardRepository(ExamContext context) : base(context)
        {
        }

        public async Task<string> GetAddress(int wardId)
        {
            var result = _context.Ward.Where(w => w.Id == wardId)
                .Include(w => w.District)
                .ThenInclude(w => w.Province)
                .Select(x => $"{x.Name}, {x.District.Name}, {x.District.Province.Name}")
                .FirstOrDefault();
            return result;
        }
    }
}
