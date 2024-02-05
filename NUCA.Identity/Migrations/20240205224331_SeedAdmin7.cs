using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NUCA.Identity.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdmin7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "super-admin",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAIAAYagAAAAEAqH9QpaQmyGxUNstnfy/1TGwvfSN5h2fOHlOeBwd9bPzEPqaLrT32vLXl0h7W0WNg==", "952434bd-fc3c-44e9-b771-abf938753678" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "super-admin",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAIAAYagAAAAEP6TziJpyJngKjwRjUZWzkrtgw8wKL3P1ejeCWZbXDg40Oe147I7OsDktuUI2WCSJg==", "710db1c2-48a8-4356-ba30-ef7af812718b" });
        }
    }
}
