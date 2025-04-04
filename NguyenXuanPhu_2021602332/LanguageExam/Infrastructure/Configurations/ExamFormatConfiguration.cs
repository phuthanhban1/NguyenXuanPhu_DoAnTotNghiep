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
    public class ExamFormatConfiguration : IEntityTypeConfiguration<ExamFormat>
    {
        public void Configure(EntityTypeBuilder<ExamFormat> builder)
        {
            builder.ToTable("ExamFormats")
                .HasKey(ef => new { ef.ExamId, ef.ExamQuestionTypeId });
            builder.HasOne(ef => ef.AudioFile)
                .WithOne(af => af.ExamFormat)
                .HasForeignKey<ExamFormat>(ef => ef.AudioFileId);
        }
    }
}
