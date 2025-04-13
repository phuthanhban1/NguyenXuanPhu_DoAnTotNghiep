using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Configurations
{
    public class ExamQuestionConfiguration : IEntityTypeConfiguration<ExamQuestion>
    {
        public void Configure(EntityTypeBuilder<ExamQuestion> builder)
        {
            builder.ToTable("ExamQuestion").HasKey(eq => eq.Id);
            
            builder.HasOne(eq => eq.Exam)
                .WithOne(e => e.ExamQuestion)
                .HasForeignKey<ExamQuestion>(eq => eq.ExamId);

            builder.HasOne(eq => eq.ContentBlock)
                .WithOne(cb => cb.ExamQuestion)
                .HasForeignKey<ExamQuestion>(eq => eq.ContentBlockId);
        }
    }
}
