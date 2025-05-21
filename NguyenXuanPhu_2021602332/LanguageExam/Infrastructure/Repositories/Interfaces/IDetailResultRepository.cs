using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IDetailResultRepository : IGenericRepository<DetailResult>
    {
        Task<List<DetailResult>> GetDetailResultsByExamUser(Guid examId, Guid userId);
    }
}
