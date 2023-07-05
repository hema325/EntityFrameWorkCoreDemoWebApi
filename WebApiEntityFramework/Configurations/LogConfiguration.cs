using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiEntityFramework.Entities;

namespace WebApiEntityFramework.Configurations
{
    public class LogConfiguration : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            //builder.Property(p => p.Id).ValueGeneratedNever();
        }
    }
}
