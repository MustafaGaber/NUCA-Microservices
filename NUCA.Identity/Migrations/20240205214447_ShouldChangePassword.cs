using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NUCA.Identity.Migrations
{
    /// <inheritdoc />
    public partial class ShouldChangePassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d902281c-4ae2-428b-8dfe-b4560e921be4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e40c846c-e7ae-4f36-8456-9ed6e0c32660");

            migrationBuilder.AddColumn<bool>(
                name: "ShouldChangePassword",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "PublicName" },
                values: new object[,]
                {
                    { "8089d2fa-b5d0-4539-a86a-1911513d3647", null, "admin", "ADMIN", "مسؤل النظام" },
                    { "c207d945-15a3-4d0b-89d7-23de97a8eac8", null, "superAdmin", "SUPERADMIN", "مدير النظام" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8089d2fa-b5d0-4539-a86a-1911513d3647");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c207d945-15a3-4d0b-89d7-23de97a8eac8");

            migrationBuilder.DropColumn(
                name: "ShouldChangePassword",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "PublicName" },
                values: new object[,]
                {
                    { "d902281c-4ae2-428b-8dfe-b4560e921be4", null, "admin", "ADMIN", "مسؤل النظام" },
                    { "e40c846c-e7ae-4f36-8456-9ed6e0c32660", null, "superAdmin", "SUPERADMIN", "مدير النظام" }
                });
        }
    }
}
