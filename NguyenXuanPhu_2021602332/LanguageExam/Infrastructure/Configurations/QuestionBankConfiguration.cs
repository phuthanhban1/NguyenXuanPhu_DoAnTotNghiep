using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class QuestionBankConfiguration : IEntityTypeConfiguration<QuestionBank>
    {
        public void Configure(EntityTypeBuilder<QuestionBank> builder)
        {
            builder.ToTable("QuestionBank")
                .HasKey(q => q.Id);
            builder.HasOne(q => q.Manager)
                .WithMany(u => u.QuestionBanks)
                .HasForeignKey(q => q.ManagerId);
            builder.HasIndex(q => q.Name).IsUnique();
 
        }
    }
}
