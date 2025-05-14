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
    public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.ToTable("Answer");
            builder.HasKey(a => a.Id);

            builder.HasMany(dr => dr.DetailResults)
                .WithOne(a => a.Answer)
                .HasForeignKey(dr => dr.AnswerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(q => q.Question)
                .WithMany(a => a.Answers)
                .HasForeignKey(a => a.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
