using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NUCA.Identity.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdmin5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "super-admin",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAIAAYagAAAAENTLqBPuzIbxBDxsndWj20zI/l+swANvJqBSu04oAdrlH0o+5+nkQwAkaIUlh1PhDQ==", "710db1c2-48a8-4356-ba30-ef7af812718b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "super-admin",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { null, null });
        }
    }
}
