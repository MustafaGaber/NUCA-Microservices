using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NUCA.Projects.Migrations
{
    /// <inheritdoc />
    public partial class AdjustmentAdvancedPaymentDeduction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AdvancedPaymentDeductions_AdjustmentId",
                table: "AdvancedPaymentDeductions",
                column: "AdjustmentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AdvancedPaymentDeductions_Adjustments_AdjustmentId",
                table: "AdvancedPaymentDeductions",
                column: "AdjustmentId",
                principalTable: "Adjustments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvancedPaymentDeductions_Adjustments_AdjustmentId",
                table: "AdvancedPaymentDeductions");

            migrationBuilder.DropIndex(
                name: "IX_AdvancedPaymentDeductions_AdjustmentId",
                table: "AdvancedPaymentDeductions");
        }
    }
}
