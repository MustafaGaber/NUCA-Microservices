using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NUCA.Projects.Migrations
{
    /// <inheritdoc />
    public partial class AdvancePaymentLedger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AdvancePaymentLedgerId",
                table: "Projects",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_AdvancePaymentLedgerId",
                table: "Projects",
                column: "AdvancePaymentLedgerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Ledgers_AdvancePaymentLedgerId",
                table: "Projects",
                column: "AdvancePaymentLedgerId",
                principalTable: "Ledgers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Ledgers_AdvancePaymentLedgerId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_AdvancePaymentLedgerId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "AdvancePaymentLedgerId",
                table: "Projects");
        }
    }
}
