using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NUCA.Projects.Migrations
{
    /// <inheritdoc />
    public partial class TahyaMisrFund : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TahyaMisrFundValue",
                table: "Adjustments",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TahyaMisrFundValue",
                table: "Adjustments");
        }
    }
}
