using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiEntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class addingConversionToCinemaHall : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "CinemaHalls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "TwoDimensions",
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: "TwoDimensions");

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: "ThreeDimensions");

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 3,
                column: "Type",
                value: "TwoDimensions");

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 4,
                column: "Type",
                value: "ThreeDimensions");

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 5,
                column: "Type",
                value: "TwoDimensions");

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 6,
                column: "Type",
                value: "ThreeDimensions");

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 7,
                column: "Type",
                value: "CXC");

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 8,
                column: "Type",
                value: "TwoDimensions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "CinemaHalls",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "TwoDimensions");

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: 2);

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 3,
                column: "Type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 4,
                column: "Type",
                value: 2);

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 5,
                column: "Type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 6,
                column: "Type",
                value: 2);

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 7,
                column: "Type",
                value: 3);

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 8,
                column: "Type",
                value: 1);
        }
    }
}
