using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class FileConfiguration : IEntityTypeConfiguration<Domain.Entities.File>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.File> builder)
        {
            builder.ToTable("ImageFile").HasKey(i => i.Id);
        }
    }
}
