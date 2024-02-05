using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NUCA.Identity.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdmin8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "super-admin",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAIAAYagAAAAEHLgEaxbJoppt7M8VbOs+Lw5Y+78z36o2MMFwC5eiS+CB396iP8FKViv89p0qEyZJQ==", "95dab7a9-34e0-47ee-a740-8f3e21b7e472" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "super-admin",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAIAAYagAAAAEAqH9QpaQmyGxUNstnfy/1TGwvfSN5h2fOHlOeBwd9bPzEPqaLrT32vLXl0h7W0WNg==", "952434bd-fc3c-44e9-b771-abf938753678" });
        }
    }
}
