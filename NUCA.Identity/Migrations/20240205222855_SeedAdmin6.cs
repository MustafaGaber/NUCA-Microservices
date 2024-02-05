using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NUCA.Identity.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdmin6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "super-admin",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEP6TziJpyJngKjwRjUZWzkrtgw8wKL3P1ejeCWZbXDg40Oe147I7OsDktuUI2WCSJg==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "super-admin",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAENTLqBPuzIbxBDxsndWj20zI/l+swANvJqBSu04oAdrlH0o+5+nkQwAkaIUlh1PhDQ==");
        }
    }
}
