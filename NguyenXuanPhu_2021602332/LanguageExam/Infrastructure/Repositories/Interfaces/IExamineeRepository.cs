using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IExamineeRepository : IGenericRepository<Examinee>
    {
        Task<Examinee> GetByExamAndUserId(Guid examId, Guid userId);

        Task<List<Examinee>> GetExamineesByExamId(Guid examId);
        Task<List<Examinee>> GetExamineesByUserId(Guid userId);
    }
}
