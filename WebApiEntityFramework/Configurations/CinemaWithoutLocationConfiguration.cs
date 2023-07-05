using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiEntityFramework.KeyLessEntities;

namespace WebApiEntityFramework.Configurations
{
    public class CinemaWithoutLocationConfiguration : IEntityTypeConfiguration<CinemaWithoutLocation>
    {
        public void Configure(EntityTypeBuilder<CinemaWithoutLocation> builder)
        {
            //to view is used only for preventing migration although we can use other way to prevent it 
            builder.HasNoKey().ToSqlQuery("select id,name from cinemas").ToView(null);
            //builder.HasNoKey().ToTable("cinemas").ToView(null); same as above
        }
    }
}
