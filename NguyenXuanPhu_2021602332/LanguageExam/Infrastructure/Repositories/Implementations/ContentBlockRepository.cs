using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Repositories.Interfaces;

namespace Infrastructure.Repositories.Implementations
{
    public class ContentBlockRepository : GenericRepository<ContentBlock>, IContentBlockRepository
    {
        public ContentBlockRepository(ExamContext context) : base(context)
        {
        }
    }
}
