
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiEntityFramework.Entities;

namespace WebApiEntityFramework.Configurations
{
    public class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired(true);
            builder.Property(p => p.Biography).HasColumnType("text").IsRequired(false);
            builder.Property(p => p.DateOfBirth).HasColumnType("date").IsRequired(true);

            builder.Ignore(p => p.Age);
            //builder.Ignore(p=>p.Address);

            builder.OwnsOne(a => a.BillingAddress);
            builder.OwnsOne(a => a.HomeAddress);
        }
    }
}
