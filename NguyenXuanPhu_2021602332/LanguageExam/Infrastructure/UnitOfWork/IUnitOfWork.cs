using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        IAnswerRepository Answers { get;}
        IExamFileRepository ExamFiles { get;}
        IContentBlockRepository ContentBlocks { get; }
        IDetailResultRepository DetailResults { get; }
        IDistrictRepository Districts { get; }
        IExamineeRepository Examinees { get; }
        IExamQuestionRepository ExamQuestions { get; }
        IExamRepository Exams { get; }
        IProvinceRepository Provinces { get; }
        IQuestionBankRepository QuestionBanks { get; }
        IQuestionTypeRepository QuestionTypes { get; }
        IQuestionRepository Questions { get; }
        ISkillRepository Skills { get; }
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        IWardRepository Wards { get; }
        Task<int> SaveChangeAsync();
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
        
    }
}
