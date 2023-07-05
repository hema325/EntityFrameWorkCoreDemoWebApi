using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiEntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddingCinemaDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CinemaDeatails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    History = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Values = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Missions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeOfCoduct = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaDeatails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CinemaDeatails_Cinemas_Id",
                        column: x => x.Id,
                        principalTable: "Cinemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CinemaDeatails");
        }
    }
}
