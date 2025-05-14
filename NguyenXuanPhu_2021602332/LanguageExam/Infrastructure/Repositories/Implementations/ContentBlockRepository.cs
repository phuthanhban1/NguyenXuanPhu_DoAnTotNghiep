using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Implementations
{
    public class ContentBlockRepository : GenericRepository<ContentBlock>, IContentBlockRepository
    {
        public ContentBlockRepository(ExamContext context) : base(context)
        {
        }

        public async Task<List<ContentBlock>> GetByQuestionTypeId(Guid id)
        {
            var list = _context.Set<ContentBlock>().Where(c => c.QuestionTypeId == id).ToList();
            return list;
        }

        public async Task<List<ContentBlock>> GetByStatus(Guid questionTypeId, byte status)
        {
            var list = _context.Set<ContentBlock>()
                .Include(x => x.QuestionType)
                .Include(x => x.AudioFile)
                .Include(x => x.ImageFile)
                .Include(x => x.Questions).ThenInclude(x => x.Answers)
                .Where(x => x.QuestionTypeId == questionTypeId && x.Status == status).ToList();
            return list;
        }
    }
}
