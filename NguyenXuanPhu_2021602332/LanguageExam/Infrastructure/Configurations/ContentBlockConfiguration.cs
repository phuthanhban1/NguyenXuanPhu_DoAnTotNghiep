using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class ContentBlockConfiguration : IEntityTypeConfiguration<ContentBlock>
    {
        public void Configure(EntityTypeBuilder<ContentBlock> builder)
        {
            builder.ToTable("ContentBlock");
            builder.HasKey(cb => cb.Id);

            builder.HasOne(cb => cb.AudioFile)
                   .WithOne(af => af.AudioContentBlock)
                   .HasForeignKey<ContentBlock>(cb => cb.AudioFileId);

            builder.HasOne(cb => cb.ImageFile)
                   .WithOne(af => af.ImageContentBlock)
                   .HasForeignKey<ContentBlock>(cb => cb.ImageFileId);

            builder.HasOne(cb => cb.QuestionType)
                   .WithMany(ql => ql.ContentBlocks)
                   .HasForeignKey(cb => cb.QuestionTypeId);
        }
    }

}
