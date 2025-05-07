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
    public class QuestionTypeConfiguration : IEntityTypeConfiguration<QuestionType>
    {
        public void Configure(EntityTypeBuilder<QuestionType> builder)
        {
            builder.ToTable("QuestionType");
            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.Skill)
                   .WithMany(q => q.QuestionTypes)
                   .HasForeignKey(a => a.SkillId);
        }
    }
    
}
