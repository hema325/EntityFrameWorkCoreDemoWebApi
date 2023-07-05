using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiEntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class addingAuditableEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Genres",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Genres",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "test",
                table: "Genres",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedBy", "ModifiedBy", "test" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedBy", "ModifiedBy", "test" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedBy", "ModifiedBy", "test" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedBy", "ModifiedBy", "test" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedBy", "ModifiedBy", "test" },
                values: new object[] { null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "test",
                table: "Genres");
        }
    }
}
