using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class DetailResultConfiguration : IEntityTypeConfiguration<DetailResult>
    {
        public void Configure(EntityTypeBuilder<DetailResult> builder)
        {
            builder.ToTable("DetailResult");
            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.Examinee)
                   .WithMany(q => q.DetailResults)
                   .HasForeignKey(a => new {a.UserId , a.ExamId});

            builder.HasOne(a => a.Answer)
                     .WithMany(q => q.DetailResults)
                     .HasForeignKey(a => a.AnswerId)
                     .OnDelete(DeleteBehavior.NoAction);
        }
    }
    
}
