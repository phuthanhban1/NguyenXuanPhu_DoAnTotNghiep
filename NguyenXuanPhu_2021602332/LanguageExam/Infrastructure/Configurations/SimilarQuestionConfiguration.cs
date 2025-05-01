using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class SimilarQuestionConfiguration : IEntityTypeConfiguration<SimilarQuestion>
    {
        public void Configure(EntityTypeBuilder<SimilarQuestion> builder)
        {
            builder.ToTable("SimilarQuestion");
            builder.HasKey(sq => new { sq.ContentBlockId1, sq.ContentBlockId2 });
            builder.HasOne(sq => sq.ContentBlock1)
                   .WithMany(cb => cb.SimilarQuestions)
                   .HasForeignKey(sq => sq.ContentBlockId1)
                   .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(sq => sq.ContentBlock2)
                   .WithMany(cb => cb.SimilarQuestions)
                   .HasForeignKey(sq => sq.ContentBlockId2)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
