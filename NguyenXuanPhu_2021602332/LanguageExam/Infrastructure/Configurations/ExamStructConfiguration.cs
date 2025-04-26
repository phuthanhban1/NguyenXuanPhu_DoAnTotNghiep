using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class ExamStructConfiguration : IEntityTypeConfiguration<ExamStruct>
    {
        public void Configure(EntityTypeBuilder<ExamStruct> builder)
        {
            builder.ToTable("ExamStruct");
            builder.HasKey(q => q.Id);
            builder.HasOne(q => q.QuestionLevel)
                .WithMany(q => q.ExamStructs)
                .HasForeignKey(q => q.QuestionLevelId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        
    }
    
}
