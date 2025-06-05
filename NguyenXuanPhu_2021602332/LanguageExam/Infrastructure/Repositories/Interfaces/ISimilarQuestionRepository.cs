using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interfaces
{
    public interface ISimilarQuestionRepository : IGenericRepository<SimilarQuestion>
    {
        Task<List<SimilarQuestion>> GetSimilarQuestions(Guid id);
        Task<List<SimilarQuestion>> GetSimilarQuestionsById(Guid id);
    }
}
