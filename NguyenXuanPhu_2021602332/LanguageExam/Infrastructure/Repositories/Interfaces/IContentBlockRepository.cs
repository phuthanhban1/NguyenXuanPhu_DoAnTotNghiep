using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IContentBlockRepository : IGenericRepository<ContentBlock>
    {
        Task<List<ContentBlock>> GetByQuestionTypeId(Guid id);
        Task<List<ContentBlock>> GetByStatus(Guid questionTypeId, byte status);
        Task ChangeStatus(Guid id, byte status);
    }
}
