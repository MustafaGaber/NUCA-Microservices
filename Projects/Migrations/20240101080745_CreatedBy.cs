using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NUCA.Projects.Migrations
{
    /// <inheritdoc />
    public partial class CreatedBy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "WorkTypes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "WorkTypes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "StatementWithholding",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "StatementWithholding",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "StatementTable",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "StatementTable",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "StatementSection",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "StatementSection",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "Statements",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "Statements",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "StatementItem",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "StatementItem",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "Projects",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "Projects",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "Privilege",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "Privilege",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "PercentageDetail",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "PercentageDetail",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "Ledgers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "Ledgers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "ExternalSuppliesItem",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "ExternalSuppliesItem",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "DepartmentUser",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "DepartmentUser",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "Departments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "Departments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "Companies",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "Companies",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "BoqTable",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "BoqTable",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "BoqSection",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "BoqSection",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "Boqs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "Boqs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "BoqItem",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "BoqItem",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "AwardTypes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "AwardTypes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "AdjustmentWithholding",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "AdjustmentWithholding",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "Adjustments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "Adjustments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "WorkTypes");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "WorkTypes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "StatementWithholding");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "StatementWithholding");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "StatementTable");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "StatementTable");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "StatementSection");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "StatementSection");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Statements");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Statements");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "StatementItem");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "StatementItem");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Privilege");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Privilege");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PercentageDetail");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "PercentageDetail");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Ledgers");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Ledgers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ExternalSuppliesItem");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ExternalSuppliesItem");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "DepartmentUser");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "DepartmentUser");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BoqTable");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "BoqTable");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BoqSection");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "BoqSection");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Boqs");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Boqs");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BoqItem");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "BoqItem");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AwardTypes");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "AwardTypes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AdjustmentWithholding");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "AdjustmentWithholding");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Adjustments");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Adjustments");
        }
    }
}
