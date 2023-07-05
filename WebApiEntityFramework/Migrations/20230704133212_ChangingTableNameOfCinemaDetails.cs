using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiEntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class ChangingTableNameOfCinemaDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinemaDeatails_Cinemas_Id",
                table: "CinemaDeatails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CinemaDeatails",
                table: "CinemaDeatails");

            migrationBuilder.RenameTable(
                name: "CinemaDeatails",
                newName: "CinemaDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CinemaDetails",
                table: "CinemaDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaDetails_Cinemas_Id",
                table: "CinemaDetails",
                column: "Id",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinemaDetails_Cinemas_Id",
                table: "CinemaDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CinemaDetails",
                table: "CinemaDetails");

            migrationBuilder.RenameTable(
                name: "CinemaDetails",
                newName: "CinemaDeatails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CinemaDeatails",
                table: "CinemaDeatails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaDeatails_Cinemas_Id",
                table: "CinemaDeatails",
                column: "Id",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
