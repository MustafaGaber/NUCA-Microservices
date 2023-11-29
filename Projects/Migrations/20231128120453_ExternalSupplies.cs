using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NUCA.Projects.Migrations
{
    /// <inheritdoc />
    public partial class ExternalSupplies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "StatementItem");

            migrationBuilder.AddColumn<long>(
                name: "DepartmentId",
                table: "StatementSection",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "ExternalSuppliesTable",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StatementId = table.Column<long>(type: "INTEGER", nullable: false),
                    DepartmentId = table.Column<int>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalSuppliesTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExternalSuppliesTable_Statements_StatementId",
                        column: x => x.StatementId,
                        principalTable: "Statements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExternalSuppliesItem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Index = table.Column<int>(type: "INTEGER", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    Unit = table.Column<string>(type: "TEXT", nullable: false),
                    UnitPrice = table.Column<double>(type: "REAL", nullable: false),
                    PreviousQuantity = table.Column<double>(type: "REAL", nullable: false),
                    TotalQuantity = table.Column<double>(type: "REAL", nullable: false),
                    Percentage = table.Column<double>(type: "REAL", nullable: false),
                    UserId = table.Column<long>(type: "INTEGER", nullable: true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ExternalSuppliesTableId = table.Column<long>(type: "INTEGER", nullable: true),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalSuppliesItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExternalSuppliesItem_ExternalSuppliesTable_ExternalSuppliesTableId",
                        column: x => x.ExternalSuppliesTableId,
                        principalTable: "ExternalSuppliesTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExternalSuppliesItem_ExternalSuppliesTableId",
                table: "ExternalSuppliesItem",
                column: "ExternalSuppliesTableId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalSuppliesTable_StatementId",
                table: "ExternalSuppliesTable",
                column: "StatementId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExternalSuppliesItem");

            migrationBuilder.DropTable(
                name: "ExternalSuppliesTable");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "StatementSection");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "StatementItem",
                type: "TEXT",
                nullable: true);
        }
    }
}
