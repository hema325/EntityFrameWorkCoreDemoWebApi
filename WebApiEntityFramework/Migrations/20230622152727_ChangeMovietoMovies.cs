using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiEntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class ChangeMovietoMovies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinemaHallMovie_Movie_MoviesId",
                table: "CinemaHallMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreMovie_Movie_MoviesId",
                table: "GenreMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieActors_Movie_MovieId",
                table: "MovieActors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movie",
                table: "Movie");

            migrationBuilder.RenameTable(
                name: "Movie",
                newName: "Movies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaHallMovie_Movies_MoviesId",
                table: "CinemaHallMovie",
                column: "MoviesId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreMovie_Movies_MoviesId",
                table: "GenreMovie",
                column: "MoviesId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieActors_Movies_MovieId",
                table: "MovieActors",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinemaHallMovie_Movies_MoviesId",
                table: "CinemaHallMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreMovie_Movies_MoviesId",
                table: "GenreMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieActors_Movies_MovieId",
                table: "MovieActors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.RenameTable(
                name: "Movies",
                newName: "Movie");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movie",
                table: "Movie",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaHallMovie_Movie_MoviesId",
                table: "CinemaHallMovie",
                column: "MoviesId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreMovie_Movie_MoviesId",
                table: "GenreMovie",
                column: "MoviesId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieActors_Movie_MovieId",
                table: "MovieActors",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
