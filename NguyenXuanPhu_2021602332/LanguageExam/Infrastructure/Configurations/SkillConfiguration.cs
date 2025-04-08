using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.ToTable("Skill").HasKey(s => s.Id);
            builder.HasOne(s => s.CreatedUser)
                .WithMany(u => u.CreatedQuestions)
                .HasForeignKey(s => s.CreatedUserId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(s => s.ReviewedUser)
                .WithMany(u => u.ReviewedQuestions)
                .HasForeignKey(s => s.ReviewedUserId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(s => s.AudioFile)
                .WithOne(a => a.Skill)
                .HasForeignKey<Skill>(s => s.AudioFileId);
            builder.HasOne(s => s.QuestionBank)
               .WithMany(q => q.Skills)
               .HasForeignKey(s => s.QuestionBankId);

        }
    }
}
