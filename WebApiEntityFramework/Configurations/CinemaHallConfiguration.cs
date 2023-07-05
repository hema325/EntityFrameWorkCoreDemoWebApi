using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiEntityFramework.Conversions;
using WebApiEntityFramework.Entities;
using WebApiEntityFramework.Enums;

namespace WebApiEntityFramework.Configurations
{
    public class CinemaHallConfiguration:IEntityTypeConfiguration<CinemaHall>
    {
        public void Configure(EntityTypeBuilder<CinemaHall> builder)
        {
            builder.Property(p => p.Cost).HasPrecision(9, 2).IsRequired(true);
            builder.Property(p => p.Type).HasDefaultValue(CinemaHallType.TwoDimensions).HasConversion<string>().IsRequired(true);
            builder.Property(p => p.Currency).HasConversion<CurrencyToSymbolConverter>();
        }
    }
}
