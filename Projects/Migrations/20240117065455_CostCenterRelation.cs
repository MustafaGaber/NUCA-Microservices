using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NUCA.Projects.Migrations
{
    /// <inheritdoc />
    public partial class CostCenterRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BoqTable_CostCenterId",
                table: "BoqTable");

            migrationBuilder.DropIndex(
                name: "IX_BoqTable_WorkTypeId",
                table: "BoqTable");

            migrationBuilder.DropIndex(
                name: "IX_BoqSection_CostCenterId",
                table: "BoqSection");

            migrationBuilder.DropIndex(
                name: "IX_BoqSection_WorkTypeId",
                table: "BoqSection");

            migrationBuilder.DropIndex(
                name: "IX_BoqItem_CostCenterId",
                table: "BoqItem");

            migrationBuilder.DropIndex(
                name: "IX_BoqItem_WorkTypeId",
                table: "BoqItem");

            migrationBuilder.CreateIndex(
                name: "IX_BoqTable_CostCenterId",
                table: "BoqTable",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_BoqTable_WorkTypeId",
                table: "BoqTable",
                column: "WorkTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BoqSection_CostCenterId",
                table: "BoqSection",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_BoqSection_WorkTypeId",
                table: "BoqSection",
                column: "WorkTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BoqItem_CostCenterId",
                table: "BoqItem",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_BoqItem_WorkTypeId",
                table: "BoqItem",
                column: "WorkTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BoqTable_CostCenterId",
                table: "BoqTable");

            migrationBuilder.DropIndex(
                name: "IX_BoqTable_WorkTypeId",
                table: "BoqTable");

            migrationBuilder.DropIndex(
                name: "IX_BoqSection_CostCenterId",
                table: "BoqSection");

            migrationBuilder.DropIndex(
                name: "IX_BoqSection_WorkTypeId",
                table: "BoqSection");

            migrationBuilder.DropIndex(
                name: "IX_BoqItem_CostCenterId",
                table: "BoqItem");

            migrationBuilder.DropIndex(
                name: "IX_BoqItem_WorkTypeId",
                table: "BoqItem");

            migrationBuilder.CreateIndex(
                name: "IX_BoqTable_CostCenterId",
                table: "BoqTable",
                column: "CostCenterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoqTable_WorkTypeId",
                table: "BoqTable",
                column: "WorkTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoqSection_CostCenterId",
                table: "BoqSection",
                column: "CostCenterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoqSection_WorkTypeId",
                table: "BoqSection",
                column: "WorkTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoqItem_CostCenterId",
                table: "BoqItem",
                column: "CostCenterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoqItem_WorkTypeId",
                table: "BoqItem",
                column: "WorkTypeId",
                unique: true);
        }
    }
}
