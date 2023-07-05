using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiEntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddingAddressColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Cinemas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Cinemas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BillingAddress_Country",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BillingAddress_Street",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HomeAddress_Country",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HomeAddress_Street",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Cinemas");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Cinemas");

            migrationBuilder.DropColumn(
                name: "BillingAddress_Country",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "BillingAddress_Street",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "HomeAddress_Country",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "HomeAddress_Street",
                table: "Actors");
        }
    }
}
