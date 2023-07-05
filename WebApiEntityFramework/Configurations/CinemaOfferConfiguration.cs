using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiEntityFramework.Entities;

namespace WebApiEntityFramework.Configurations
{
    public class CinemaOfferConfiguration:IEntityTypeConfiguration<CinemaOffer>
    {
        public void Configure(EntityTypeBuilder<CinemaOffer> builder)
        {
            builder.Property(p => p.Begin).IsRequired(true);
            builder.Property(p => p.End).IsRequired(true);
            builder.Property(p => p.DiscountPercentage).HasPrecision(5, 2).IsRequired(true);
        }
    }
}
