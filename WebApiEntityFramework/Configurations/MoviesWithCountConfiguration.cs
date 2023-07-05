using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiEntityFramework.KeyLessEntities;

namespace WebApiEntityFramework.Configurations
{
    public class MoviesWithCountConfiguration : IEntityTypeConfiguration<MoviesWithCount>
    {
        public void Configure(EntityTypeBuilder<MoviesWithCount> builder)
        {
            //builder.HasNoKey().ToView("MoviesWithCounts"); same as below
            builder.HasNoKey().ToSqlQuery(@"Select Id, Title,
                                    (Select count(*) FROM GenreMovie where MoviesId = movies.Id) as AmountGenres,
                                    (Select count(distinct moviesId) from CinemaHallMovie
                                    	INNER JOIN CinemaHalls
                                    	ON CinemaHalls.Id = CinemaHallMovie.CinemaHallsId
                                    	where MoviesId = movies.Id) as AmountCinemas,
                                    (Select count(*) from MovieActors where MovieId = movies.Id) as AmountActors
                                    FROM Movies").ToView(null);
        }
    }
}
