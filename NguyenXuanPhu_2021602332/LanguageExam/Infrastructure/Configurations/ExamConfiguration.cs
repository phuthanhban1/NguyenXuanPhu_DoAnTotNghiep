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
    public class ExamConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.ToTable("Exams")
                .HasKey(e => e.Id);
            builder.HasOne(e => e.CreatedUser)
                .WithMany(u => u.Exams)
                .HasForeignKey(e => e.CreatedUserId);
        }
    }
}
