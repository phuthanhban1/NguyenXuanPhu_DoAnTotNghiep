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
        public DbSet<ContentBlock> ContentBlock { get; set; }
        public DbSet<DetailResult> DetailResult { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<Exam> Exam { get; set; }
        public DbSet<Examinee> Examinee { get; set; }
        public DbSet<ExamQuestion> ExamQuestion { get; set; }
        public DbSet<ExamFile> File { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<QuestionBank> QuestionBank { get; set; }
        public DbSet<QuestionType> QuestionType { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Ward> Ward { get; set; }
        public DbSet<ExamStruct> ExamStruct { get; set; }
        public DbSet<ExamStructDetail> ExamStructDetail { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExamContext).Assembly);
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = Guid.Parse("2959CA56-A667-46A0-ACEA-EBA1E9961419"), Name = "quản trị viên" },
                new Role { Id = Guid.Parse("85AF4517-BE3B-4EA9-B2CD-1AD9B4417870"), Name = "quản lý kỳ thi" },
                new Role { Id = Guid.Parse("45B76D26-26E2-41D1-A0F7-ED6B55DC2190"), Name = "người tạo đề" },
                new Role { Id = Guid.Parse("316F8C9C-A9A2-4B17-B4C4-6434D165BC62"), Name = "quản lý ngân hàng câu hỏi"},
                new Role { Id = Guid.Parse("93D09639-A7B9-4825-B364-30366908B007"), Name = "người tạo câu hỏi" },
                new Role { Id = Guid.Parse("61AF889A-7617-43E7-9CB2-537A01E97A34"), Name = "người đánh giá câu hỏi" },
                new Role { Id = Guid.Parse("A0E4F1D5-3C8B-4F2A-8E6C-7D9B5E0A2F1D"), Name = "thí sinh" }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = Guid.NewGuid(), FullName = "Nguyễn Xuân Phú", RoleId = Guid.Parse("2959CA56-A667-46A0-ACEA-EBA1E9961419"),
                    Email = "phuthanhban3@gmail.com", Password = "1" },
                new User
                {
                    Id = Guid.Parse("93D09639-A7B9-4825-B364-30366908B007"),
                    FullName = "Tạo Câu Hỏi",
                    RoleId = Guid.Parse("93D09639-A7B9-4825-B364-30366908B007"),
                    Email = "taocau@gmail.com",
                    Password = "1"
                },
                new User
                {
                    Id = Guid.Parse("8A7DD16F-85BF-4143-BE0B-A31DA3BBE44A"),
                    FullName = "Quản lý bank",
                    RoleId = Guid.Parse("316F8C9C-A9A2-4B17-B4C4-6434D165BC62"),
                    Email = "quanlybank@gmail.com",
                    Password = "1"
                },
                new User
                {
                    Id = Guid.Parse("61AF889A-7617-43E7-9CB2-537A01E97A34"),
                    FullName = "Đánh Giá Câu",
                    RoleId = Guid.Parse("61AF889A-7617-43E7-9CB2-537A01E97A34"),
                    Email = "review@gmail.com",
                    Password = "1"
                }
            );
            modelBuilder.Entity<QuestionBank>().HasData(
               new QuestionBank
               {
                   Id = Guid.Parse("61AF889A-7617-43E7-9CB2-537A01E97A34"),
                   CreatedDate = DateOnly.FromDateTime(DateTime.Now),
                   Language = "Hàn",
                   ManagerId = Guid.Parse("8A7DD16F-85BF-4143-BE0B-A31DA3BBE44A"),
                   Name = "Topik 1",

                   Status = 0
               }
            );
            modelBuilder.Entity<Skill>().HasData(
                new Skill
                {
                    Id = Guid.Parse("61AF889A-7617-43E7-9CB2-537A01E97A34"),
                    Name = "Đọc",
                    CreatedUserId = Guid.Parse("93D09639-A7B9-4825-B364-30366908B007"),
                    ReviewedUserId = Guid.Parse("61AF889A-7617-43E7-9CB2-537A01E97A34"),
                    QuestionBankId = Guid.Parse("61AF889A-7617-43E7-9CB2-537A01E97A34")
                }
            );
        }
    }
}
