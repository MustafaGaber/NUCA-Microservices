using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NUCA.Identity.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdmin3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "48b14da1-70dc-46fc-8cbe-1e287e9268f5", null, "admin", "ADMIN", "مسؤل النظام" },
                    { "cdd39396-27da-48d2-b2d5-9f8103441464", null, "superAdmin", "SUPERADMIN", "مدير النظام" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NationalId", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "ShouldChangePassword", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3079b198-824a-499d-a32c-0e9185296b7d", 0, null, null, false, "Super Admin", false, null, "", null, "SUPERADMIN", null, "", false, null, true, false, "SuperAdmin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48b14da1-70dc-46fc-8cbe-1e287e9268f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cdd39396-27da-48d2-b2d5-9f8103441464");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3079b198-824a-499d-a32c-0e9185296b7d");

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
    }
}
