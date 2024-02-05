using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NUCA.Identity.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAdminSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "super-admin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NationalId", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "ShouldChangePassword", "TwoFactorEnabled", "UserName" },
                values: new object[] { "super-admin", 0, null, null, false, "Super Admin", false, null, "", null, "SUPERADMIN", "AQAAAAIAAYagAAAAEHLgEaxbJoppt7M8VbOs+Lw5Y+78z36o2MMFwC5eiS+CB396iP8FKViv89p0qEyZJQ==", "", false, "95dab7a9-34e0-47ee-a740-8f3e21b7e472", true, false, "SuperAdmin" });
        }
    }
}
