using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiEntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddingViewMovieCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW dbo.MoviesWithCounts
                                    as
                                    Select Id, Title,
                                    (Select count(*) FROM GenreMovie where MoviesId = movies.Id) as AmountGenres,
                                    (Select count(distinct moviesId) from CinemaHallMovie
                                    	INNER JOIN CinemaHalls
                                    	ON CinemaHalls.Id = CinemaHallMovie.CinemaHallsId
                                    	where MoviesId = movies.Id) as AmountCinemas,
                                    (Select count(*) from MovieActors where MovieId = movies.Id) as AmountActors
                                    FROM Movies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW dbo.MoviesWithCounts");
        }
    }
}
