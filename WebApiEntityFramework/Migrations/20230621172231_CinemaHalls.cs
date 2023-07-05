using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiEntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class CinemaHalls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CinemaHall",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cost = table.Column<decimal>(type: "decimal(9,2)", precision: 9, scale: 2, nullable: false),
                    CinemaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaHall", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CinemaHall_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CinemaHall_CinemaId",
                table: "CinemaHall",
                column: "CinemaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CinemaHall");
        }
    }
}
