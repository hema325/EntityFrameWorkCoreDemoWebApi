using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiEntityFramework.Entities;

namespace WebApiEntityFramework.Configurations
{
    public class MovieConfiguration:IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(p => p.Title).HasMaxLength(250).IsRequired(true);
            builder.Property(p => p.ReleaseDate).HasColumnType("date").IsRequired(true);
            builder.Property(p => p.PosterURL).HasMaxLength(450).IsUnicode(false).IsRequired(true);

            builder.HasMany(m => m.Genres).WithMany(g => g.Movies);
        }
    }
}
