using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NUCA.Identity.Migrations
{
    /// <inheritdoc />
    public partial class Cities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CityAuthorityUser_CityAuthority_AuthoritiesId",
                table: "CityAuthorityUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CityAuthority",
                table: "CityAuthority");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32ea5e42-9a0b-4636-8c2c-3917695c398b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed8d2b7a-1214-4dcb-87da-a7897ea5d300");

            migrationBuilder.RenameTable(
                name: "CityAuthority",
                newName: "CityAuthorities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CityAuthorities",
                table: "CityAuthorities",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "PublicName" },
                values: new object[,]
                {
                    { "c4af620e-e365-4de8-9c28-f0fc7ad3a0ef", null, "admin", "ADMIN", "مسؤل النظام" },
                    { "cadb3a96-646b-4107-a717-7cc0923c663a", null, "superAdmin", "SUPERADMIN", "مدير النظام" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CityAuthorityUser_CityAuthorities_AuthoritiesId",
                table: "CityAuthorityUser",
                column: "AuthoritiesId",
                principalTable: "CityAuthorities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CityAuthorityUser_CityAuthorities_AuthoritiesId",
                table: "CityAuthorityUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CityAuthorities",
                table: "CityAuthorities");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4af620e-e365-4de8-9c28-f0fc7ad3a0ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cadb3a96-646b-4107-a717-7cc0923c663a");

            migrationBuilder.RenameTable(
                name: "CityAuthorities",
                newName: "CityAuthority");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CityAuthority",
                table: "CityAuthority",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "PublicName" },
                values: new object[,]
                {
                    { "32ea5e42-9a0b-4636-8c2c-3917695c398b", null, "superAdmin", "SUPERADMIN", "مدير النظام" },
                    { "ed8d2b7a-1214-4dcb-87da-a7897ea5d300", null, "admin", "ADMIN", "مسؤل النظام" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CityAuthorityUser_CityAuthority_AuthoritiesId",
                table: "CityAuthorityUser",
                column: "AuthoritiesId",
                principalTable: "CityAuthority",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
