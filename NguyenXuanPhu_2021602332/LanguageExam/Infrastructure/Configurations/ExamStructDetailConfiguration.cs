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
    public class ExamStructDetailConfiguration : IEntityTypeConfiguration<ExamStructDetail>
    {
        public void Configure(EntityTypeBuilder<ExamStructDetail> builder)
        {
            builder.ToTable("ExamStructDetail");
            builder.HasKey(e => e.Id);
            builder.HasOne(e => e.ExamStruct)
                .WithMany(es => es.ExamStructDetails)
                .HasForeignKey(e => e.ExamStructId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.QuestionType)
                .WithMany(es => es.ExamStructDetails)
                .HasForeignKey(e => e.QuestionTypeId);
        }
    }
}
