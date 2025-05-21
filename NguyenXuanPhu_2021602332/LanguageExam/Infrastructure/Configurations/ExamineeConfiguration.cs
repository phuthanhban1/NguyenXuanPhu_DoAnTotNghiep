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
    public class ExamineeConfiguration : IEntityTypeConfiguration<Examinee>
    {
        public void Configure(EntityTypeBuilder<Examinee> builder)
        {
            builder.ToTable("Examinee");
            builder.HasKey(a => new {a.ExamId, a.UserId});
            builder.HasOne(a => a.Room)
                .WithMany(b => b.Examinees)
                .HasForeignKey(a => a.RoomId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(em => em.User)
                .WithMany(u => u.Examinees)
                .HasForeignKey(em => em.UserId);
            builder.HasOne(em => em.Exam)
                .WithMany(u => u.Examinees)
                .HasForeignKey(em => em.ExamId);
            
        }
    }
}
