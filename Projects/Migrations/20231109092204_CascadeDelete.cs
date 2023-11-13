using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NUCA.Projects.Migrations
{
    /// <inheritdoc />
    public partial class CascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatementWithholding_Statements_StatementId",
                table: "StatementWithholding");

            migrationBuilder.AddForeignKey(
                name: "FK_StatementWithholding_Statements_StatementId",
                table: "StatementWithholding",
                column: "StatementId",
                principalTable: "Statements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatementWithholding_Statements_StatementId",
                table: "StatementWithholding");

            migrationBuilder.AddForeignKey(
                name: "FK_StatementWithholding_Statements_StatementId",
                table: "StatementWithholding",
                column: "StatementId",
                principalTable: "Statements",
                principalColumn: "Id");
        }
    }
}
