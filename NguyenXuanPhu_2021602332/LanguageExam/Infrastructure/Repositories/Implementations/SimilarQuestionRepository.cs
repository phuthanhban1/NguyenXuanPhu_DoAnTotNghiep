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
    public class SimilarQuestionRepository : GenericRepository<SimilarQuestion>, ISimilarQuestionRepository
    {
        public SimilarQuestionRepository(ExamContext context) : base(context)
        {
        }

        public async Task<List<SimilarQuestion>> GetSimilarQuestions(Guid id)
        {
            var list = _context.Set<SimilarQuestion>().Where(s => s.ContentBlockId1 == id || s.ContentBlockId2 == id).ToList();
            foreach (var s in list)
            {
                if (s.ContentBlockId1 == id) s.ContentBlockId1 = s.ContentBlockId2;
                if (s.ContentBlockId2 == id) s.ContentBlockId2 = s.ContentBlockId1;
            };
            return list;
        }
        public async Task<List<SimilarQuestion>> GetSimilarQuestionsById(Guid id)
        {
            var list = _context.Set<SimilarQuestion>().Where(s => s.ContentBlockId1 == id || s.ContentBlockId2 == id).ToList();
            return list;
        }
    }
}
