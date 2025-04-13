using Domain.Entities;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public class ExamContext : DbContext
    {
        public ExamContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Answer> Answer { get; set; }
        public DbSet<AudioFile> AudioFile { get; set; }
        public DbSet<ContentBlock> ContentBlock { get; set; }
        public DbSet<DetailResult> DetailResult { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<Exam> Exam { get; set; }
        public DbSet<Examinee> Examinee { get; set; }
        public DbSet<ExamQuestion> ExamQuestion { get; set; }
        public DbSet<ImageFile> ImageFile { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<QuestionBank> QuestionBank { get; set; }
        public DbSet<QuestionLevel> QuestionLevel { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Ward> Ward { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExamContext).Assembly);
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = Guid.NewGuid(), Name = "Admin" },
                new Role { Id = Guid.NewGuid(), Name = "ExamManager" },
                new Role { Id = Guid.NewGuid(), Name = "TestCreator" },
                new Role { Id = Guid.NewGuid(), Name = "QuestionBankManager" },
                new Role { Id = Guid.NewGuid(), Name = "QuestionContributor" },
                new Role { Id = Guid.NewGuid(), Name = "QuestionContributor" },
                new Role { Id = Guid.NewGuid(), Name = "User" }
            );
        }
    }
}
