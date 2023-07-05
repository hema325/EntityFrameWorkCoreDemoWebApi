using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiEntityFramework.Entities;

namespace WebApiEntityFramework.Configurations
{
    public class CinemaConfiguration:IEntityTypeConfiguration<Cinema>
    {
        public void Configure(EntityTypeBuilder<Cinema> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired(true);
            builder.Property(p => p.Price).HasPrecision(9, 2).IsRequired(true);

            builder.HasOne(c => c.offer).WithOne().HasForeignKey<CinemaOffer>(o => o.CinemaId);
            //builder.HasMany(c => c.CinemaHalls).WithOne(ch => ch.Cinema).HasForeignKey(ch=>ch.CinemaId).OnDelete(DeleteBehavior.Cascade);

            builder.OwnsOne(c => c.Address, builder =>
            {
                builder.Property(p => p.Street).HasColumnName("Street");
                builder.Property(p => p.Country).HasColumnName("Country");
            });

            
        }
    }
}
