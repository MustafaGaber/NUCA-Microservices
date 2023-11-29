using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NUCA.Projects.Migrations
{
    /// <inheritdoc />
    public partial class ExternalSuppliesItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExternalSuppliesTable_Statements_StatementId",
                table: "ExternalSuppliesTable");

            migrationBuilder.DropIndex(
                name: "IX_ExternalSuppliesTable_StatementId",
                table: "ExternalSuppliesTable");

            migrationBuilder.AddColumn<long>(
                name: "StatementTableId",
                table: "ExternalSuppliesItem",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "ExternalSuppliesItem",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "StatementId",
                table: "ExternalSuppliesItem",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExternalSuppliesItem_StatementId",
                table: "ExternalSuppliesItem",
                column: "StatementId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExternalSuppliesItem_Statements_StatementId",
                table: "ExternalSuppliesItem",
                column: "StatementId",
                principalTable: "Statements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExternalSuppliesItem_Statements_StatementId",
                table: "ExternalSuppliesItem");

            migrationBuilder.DropIndex(
                name: "IX_ExternalSuppliesItem_StatementId",
                table: "ExternalSuppliesItem");

            migrationBuilder.DropColumn(
                name: "StatementTableId",
                table: "ExternalSuppliesItem");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "ExternalSuppliesItem");

            migrationBuilder.DropColumn(
                name: "StatementId",
                table: "ExternalSuppliesItem");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalSuppliesTable_StatementId",
                table: "ExternalSuppliesTable",
                column: "StatementId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExternalSuppliesTable_Statements_StatementId",
                table: "ExternalSuppliesTable",
                column: "StatementId",
                principalTable: "Statements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
