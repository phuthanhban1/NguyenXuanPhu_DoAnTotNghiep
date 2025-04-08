using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class ImageFileConfiguration : IEntityTypeConfiguration<ImageFile>
    {
        public void Configure(EntityTypeBuilder<ImageFile> builder)
        {
            builder.ToTable("ImageFile").HasKey(i => i.Id);
        }
    }
}
