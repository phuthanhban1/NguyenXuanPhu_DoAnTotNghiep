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
    public class ExamQuestionDetailConfiguration : IEntityTypeConfiguration<ExamQuestionDetail>
    {
        public void Configure(EntityTypeBuilder<ExamQuestionDetail> builder)
        {
            builder.ToTable("ExamQuestionDetail");
            builder.HasKey(e => e.Id);
            
            builder.HasOne(e => e.ContentBlock)
                .WithOne(c => c.ExamQuestionDetail)
                .HasForeignKey<ExamQuestionDetail>(e => e.ContentBlockId);
            builder.HasOne(e => e.ExamQuestion)
                .WithMany(c => c.ExamQuestionDetails)
                .HasForeignKey(e => e.ExamQuestionId);
        }
    }

}
