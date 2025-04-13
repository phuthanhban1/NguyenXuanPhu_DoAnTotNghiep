using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Repositories.Interfaces;

namespace Infrastructure.Repositories.Implementations
{
    public class WardRepository : GenericRepository<Ward>, IWardRepository
    {
        public WardRepository(ExamContext context) : base(context)
        {
        }
    }
}
