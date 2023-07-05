using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiEntityFramework.Entities;

namespace WebApiEntityFramework.Configurations
{
    public class CinemaDetailConfiguration : IEntityTypeConfiguration<CinemaDetail>
    {
        public void Configure(EntityTypeBuilder<CinemaDetail> builder)
        {
            builder.HasOne(cd => cd.Cinema).WithOne(c => c.CinemaDetail).HasForeignKey<CinemaDetail>(cd=>cd.Id);
        }
    }
}
