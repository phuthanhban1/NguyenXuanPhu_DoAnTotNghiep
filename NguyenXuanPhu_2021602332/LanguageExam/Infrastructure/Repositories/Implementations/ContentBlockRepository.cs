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

        public async Task ChangeStatus(Guid id, byte status)
        {
            var contentBlock = _context.ContentBlock.Find(id);
            contentBlock.Status = status;
            _context.Update(contentBlock);
        }

        public async Task<List<ContentBlock>> GetByQuestionTypeId(Guid id)
        {
            var list = _context.Set<ContentBlock>().Where(c => c.QuestionTypeId == id)
                .Include(x => x.Questions)
                .ToList();
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
        public async Task<List<ContentBlock>> GetByQuestionTypeScore(Guid questionTypeId, byte score)
        {
            var list = _context.Set<ContentBlock>()
                .Include(x => x.QuestionType)
                .Include(x => x.Questions)
                .Where(x => x.QuestionTypeId == questionTypeId && x.Questions.Sum(q => q.Score) == score && x.Status == 1).ToList();
            return list;
        }
        public Task<ContentBlock> GetContentBlockByIdAsync(Guid id)
        {
            var contentBlock = _context.ContentBlock
                .Include(x => x.QuestionType)
                .Include(x => x.AudioFile)
                .Include(x => x.ImageFile)
                .Include(x => x.Questions).ThenInclude(x => x.Answers)
                .FirstOrDefaultAsync(x => x.Id == id);
            return contentBlock;
        }
    }
}
