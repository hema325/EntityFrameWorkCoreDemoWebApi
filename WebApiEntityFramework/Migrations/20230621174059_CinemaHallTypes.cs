using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiEntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class CinemaHallTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinemaHall_Cinemas_CinemaId",
                table: "CinemaHall");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CinemaHall",
                table: "CinemaHall");

            migrationBuilder.RenameTable(
                name: "CinemaHall",
                newName: "CinemaHalls");

            migrationBuilder.RenameIndex(
                name: "IX_CinemaHall_CinemaId",
                table: "CinemaHalls",
                newName: "IX_CinemaHalls_CinemaId");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "CinemaHalls",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CinemaHalls",
                table: "CinemaHalls",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaHalls_Cinemas_CinemaId",
                table: "CinemaHalls",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinemaHalls_Cinemas_CinemaId",
                table: "CinemaHalls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CinemaHalls",
                table: "CinemaHalls");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "CinemaHalls");

            migrationBuilder.RenameTable(
                name: "CinemaHalls",
                newName: "CinemaHall");

            migrationBuilder.RenameIndex(
                name: "IX_CinemaHalls_CinemaId",
                table: "CinemaHall",
                newName: "IX_CinemaHall_CinemaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CinemaHall",
                table: "CinemaHall",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaHall_Cinemas_CinemaId",
                table: "CinemaHall",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
