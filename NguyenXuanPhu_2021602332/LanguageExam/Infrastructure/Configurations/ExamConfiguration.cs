using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class ExamConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.ToTable("Exam")
                .HasKey(e => e.Id);
            builder.HasOne(e => e.Manager)
                .WithMany(u => u.ManagedExam)
                .HasForeignKey(e => e.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.CreatedQuestionUser)
                .WithMany(u => u.CreatedQuestionExam)
                .HasForeignKey(e => e.CreatedQuestionUserId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
