using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.Ward)
                   .WithMany(q => q.Users)
                   .HasForeignKey(a => a.WardId);

            builder.HasOne(a => a.Role)
                   .WithMany(q => q.Users)
                   .HasForeignKey(a => a.RoleId);

            builder.HasOne(a => a.ImageFace)
                .WithOne(i => i.ImageFace)
                .HasForeignKey<User>(a => a.ImageFaceId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(a => a.ImageIdCardBefore)
                .WithOne(i => i.ImageIdCardBefore)
                .HasForeignKey<User>(a => a.ImageIdCardBeforeId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(a => a.ImageIdCardAfter)
                .WithOne(i => i.ImageIdCardAfter)
                .HasForeignKey<User>(a => a.ImageIdCardAfterId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
