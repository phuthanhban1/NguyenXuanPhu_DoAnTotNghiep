﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Question")
               .HasKey(q => q.Id);
            
            builder.HasOne(q => q.ContentBlock)
                .WithMany(cb => cb.Questions)
                .HasForeignKey(q => q.ContentBlockId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
