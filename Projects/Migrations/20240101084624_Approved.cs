using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NUCA.Projects.Migrations
{
    /// <inheritdoc />
    public partial class Approved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "Projects",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ApprovedBy",
                table: "Projects",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "Boqs",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ApprovedBy",
                table: "Boqs",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approved",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Approved",
                table: "Boqs");

            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "Boqs");
        }
    }
}
