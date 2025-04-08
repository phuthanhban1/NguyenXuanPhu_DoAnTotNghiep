using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class DistrictConfiguration : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.ToTable("District");
            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.Province)
                   .WithMany(q => q.Districts)
                   .HasForeignKey(a => a.ProvinceId);
        }
    }
    
}
