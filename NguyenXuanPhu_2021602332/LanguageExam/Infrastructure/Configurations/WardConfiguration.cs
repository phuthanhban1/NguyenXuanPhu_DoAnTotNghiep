using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class WardConfiguration : IEntityTypeConfiguration<Ward>
    {
        public void Configure(EntityTypeBuilder<Ward> builder)
        {
            builder.ToTable("Ward");
            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.District)
                   .WithMany(q => q.Wards)
                   .HasForeignKey(a => a.DistrictId);
        }
    }

}
