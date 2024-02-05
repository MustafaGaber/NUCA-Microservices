using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NUCA.Identity.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdmin2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "1b51beb4-1118-42b8-9f68-aba0cf4b5916", null, "admin", "ADMIN", "مسؤل النظام" },
                    { "dd134f4a-83a6-45c4-9edc-c08cc1a00771", null, "superAdmin", "SUPERADMIN", "مدير النظام" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NationalId", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "ShouldChangePassword", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f8d442a8-e152-4657-abc1-128416dfefe7", 0, null, null, false, "Super Admin", false, null, "", null, "SUPERADMIN", null, "", false, null, true, false, "SuperAdmin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b51beb4-1118-42b8-9f68-aba0cf4b5916");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd134f4a-83a6-45c4-9edc-c08cc1a00771");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f8d442a8-e152-4657-abc1-128416dfefe7");

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
    }
}
