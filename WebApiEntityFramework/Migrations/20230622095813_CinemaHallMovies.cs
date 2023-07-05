using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiEntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class CinemaHallMovies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BioGraphy",
                table: "Actors",
                newName: "Biography");

            migrationBuilder.CreateTable(
                name: "CinemaHallMovie",
                columns: table => new
                {
                    CinemaHallsId = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaHallMovie", x => new { x.CinemaHallsId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_CinemaHallMovie_CinemaHalls_CinemaHallsId",
                        column: x => x.CinemaHallsId,
                        principalTable: "CinemaHalls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CinemaHallMovie_Movie_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CinemaHallMovie_MoviesId",
                table: "CinemaHallMovie",
                column: "MoviesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CinemaHallMovie");

            migrationBuilder.RenameColumn(
                name: "Biography",
                table: "Actors",
                newName: "BioGraphy");
        }
    }
}
