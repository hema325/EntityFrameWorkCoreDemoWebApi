using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiEntityFramework.Entities;

namespace WebApiEntityFramework.Configurations
{
    public class MovieActorConfiguration:IEntityTypeConfiguration<MovieActor>
    {
        public void Configure(EntityTypeBuilder<MovieActor> builder)
        {
            builder.HasKey(p => new { p.MovieId, p.ActorId });
            builder.Property(p => p.Character).HasMaxLength(100).IsRequired(true);

            builder.HasOne(ma => ma.Actor).WithMany(a => a.MovieActors).HasForeignKey(ma => ma.ActorId);
            builder.HasOne(ma => ma.Movie).WithMany(m => m.MovieActors).HasForeignKey(ma => ma.MovieId);
        }
    }
}
