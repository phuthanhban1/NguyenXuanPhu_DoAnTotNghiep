using Infrastructure.Context;
using Infrastructure.Repositories.Implementations;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContextTransaction _transaction;
        protected readonly ExamContext _context;

        public UnitOfWork(ExamContext context)
        {
            _context = context;
            Answers = new AnswerRepository(_context);
            AudioFiles = new AudioFileRepository(_context);
            ContentBlocks = new ContentBlockRepository(_context);
            DetailResults = new DetailResultRepository(_context);
            Districts = new DistrictRepository(_context);
            Examinees = new ExamineeRepository(_context);
            ExamQuestions = new ExamQuestionRepository(_context);
            Exams = new ExamRepository(_context);
            ImageFiles = new ImageFileRepository(_context);
            Provinces = new ProvinceRepository(_context);
            QuestionBanks = new QuestionBankRepository(_context);
            QuestionLevels = new QuestionLevelRepository(_context);
            Questions = new QuestionRepository(_context);
            Skills = new SkillRepository(_context);
            Users = new UserRepository(_context);
            Roles = new RoleRepository(_context);
            Wards = new WardRepository(_context);
        }
        

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
            await _transaction?.CommitAsync();
        }

        public async Task RollbackAsync()
        {
            await _transaction?.RollbackAsync();
        }
        

        public IAnswerRepository Answers {get; set;}

        public IAudioFileRepository AudioFiles {get; set;}

        public IContentBlockRepository ContentBlocks {get; set;}

        public IDetailResultRepository DetailResults {get; set;}

        public IDistrictRepository Districts {get; set;}

        public IExamineeRepository Examinees {get; set;}

        public IExamQuestionRepository ExamQuestions {get; set;}

        public IExamRepository Exams {get; set;}

        public IImageFileRepository ImageFiles {get; set;}

        public IProvinceRepository Provinces {get; set;}

        public IQuestionBankRepository QuestionBanks {get; set;}

        public IQuestionLevelRepository QuestionLevels {get; set;}

        public IQuestionRepository Questions {get; set;}

        public ISkillRepository Skills {get; set;}

        public IUserRepository Users {get; set;}

        public IRoleRepository Roles {get; set;}

        public IWardRepository Wards {get; set;}

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
