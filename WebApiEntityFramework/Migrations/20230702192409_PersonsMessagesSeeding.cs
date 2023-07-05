using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApiEntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class PersonsMessagesSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Felipe" },
                    { 2, "Claudia" }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Content", "ReceiverId", "SenderId" },
                values: new object[,]
                {
                    { 1, "Hello, Claudia!", 2, 1 },
                    { 2, "Hello, Felipe, how are you?", 1, 2 },
                    { 3, "All good, and you?", 2, 1 },
                    { 4, "Very good :)", 1, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
