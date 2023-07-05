using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiEntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddingGenreIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Genres_IsDeleted",
                table: "Genres",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_Name",
                table: "Genres",
                column: "Name",
                unique: true,
                filter: "isDeleted = 'false'");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Genres_IsDeleted",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_Name",
                table: "Genres");
        }
    }
}
