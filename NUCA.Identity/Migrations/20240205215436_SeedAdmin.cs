using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NUCA.Identity.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8089d2fa-b5d0-4539-a86a-1911513d3647");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c207d945-15a3-4d0b-89d7-23de97a8eac8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "PublicName" },
                values: new object[,]
                {
                    { "3b2d6476-b8f9-4386-b66d-a7f06d0e1f46", null, "superAdmin", "SUPERADMIN", "مدير النظام" },
                    { "50d36eeb-dee9-4bfb-b69c-a016fdd9c729", null, "admin", "ADMIN", "مسؤل النظام" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NationalId", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "ShouldChangePassword", "TwoFactorEnabled", "UserName" },
                values: new object[] { "00000000-0000-0000-0000-000000000000", 0, null, null, false, "Super Admin", false, null, "", null, null, null, "", false, null, true, false, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b2d6476-b8f9-4386-b66d-a7f06d0e1f46");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50d36eeb-dee9-4bfb-b69c-a016fdd9c729");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000000");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "PublicName" },
                values: new object[,]
                {
                    { "8089d2fa-b5d0-4539-a86a-1911513d3647", null, "admin", "ADMIN", "مسؤل النظام" },
                    { "c207d945-15a3-4d0b-89d7-23de97a8eac8", null, "superAdmin", "SUPERADMIN", "مدير النظام" }
                });
        }
    }
}
