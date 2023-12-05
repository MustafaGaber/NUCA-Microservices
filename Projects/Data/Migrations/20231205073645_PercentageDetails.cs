using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NUCA.Projects.Data.Migrations
{
    /// <inheritdoc />
    public partial class PercentageDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PercentageDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Quantity = table.Column<double>(type: "REAL", nullable: false),
                    Percentage = table.Column<double>(type: "REAL", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StatementItemId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PercentageDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PercentageDetail_StatementItem_StatementItemId",
                        column: x => x.StatementItemId,
                        principalTable: "StatementItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PercentageDetail_StatementItemId",
                table: "PercentageDetail",
                column: "StatementItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PercentageDetail");
        }
    }
}
