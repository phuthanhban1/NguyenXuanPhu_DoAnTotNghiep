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
            builder.HasKey(cb => cb.Id);

            builder.Property(cb => cb.Content).IsRequired();

            builder.HasOne(cb => cb.CreatedUser)
                   .WithMany()
                   .HasForeignKey(cb => cb.CreatedUserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(cb => cb.ConfirmedUser)
                   .WithMany()
                   .HasForeignKey(cb => cb.ConfirmedUserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(cb => cb.AudioFile)
                   .WithMany()
                   .HasForeignKey(cb => cb.AudioFileId);

            builder.HasOne(cb => cb.QuestionType)
                   .WithMany(qt => qt.DetailConstructions)
                   .HasForeignKey(cb => cb.QuestionTypeId);
        }
    }

}
