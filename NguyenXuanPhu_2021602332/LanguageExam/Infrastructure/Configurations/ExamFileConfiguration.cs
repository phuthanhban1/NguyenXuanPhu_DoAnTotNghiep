using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class ExamFileConfiguration : IEntityTypeConfiguration<ExamFile>
    {
        public void Configure(EntityTypeBuilder<ExamFile> builder)
        {
            builder.ToTable("ImageFile").HasKey(i => i.Id);
        }
    }
}
