using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiEntityFramework.Entities;

namespace WebApiEntityFramework.Configurations
{
    public class GenreConfiguration:IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(p => p.Id).IsClustered(true);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired(true);
            builder.HasQueryFilter(g => !g.IsDeleted);

            builder.HasIndex(p => p.Name).IsUnique(true).HasFilter("isDeleted = 'false'");
            builder.HasIndex(p => p.IsDeleted).IsUnique(false);

            //builder.Property<DateTime>("CreatedDate").HasDefaultValueSql("GetDate()");
        }
    }
}
