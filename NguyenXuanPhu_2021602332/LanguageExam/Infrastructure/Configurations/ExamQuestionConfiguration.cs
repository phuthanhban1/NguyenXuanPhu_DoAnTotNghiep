using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Configurations
{
    public class ExamQuestionConfiguration : IEntityTypeConfiguration<ExamQuestion>
    {
        public void Configure(EntityTypeBuilder<ExamQuestion> builder)
        {
            builder.ToTable("ExamQuestions").HasKey(eq => eq.Id);
            builder.HasOne(eq => eq.CreatedUser)
                .WithOne(u => u.ExamQuestions)
                .HasForeignKey<ExamQuestion>(eq => eq.CreatedUserId);
            builder.HasOne(eq => eq.Exam)
                .WithOne(e => e.ExamQuestion)
                .HasForeignKey<ExamQuestion>(eq => eq.ExamId);
        }
    }
}
