using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NUCA.Projects.Migrations
{
    /// <inheritdoc />
    public partial class CreatedByString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "WorkTypes",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "WorkTypes",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Users",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Users",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "StatementWithholding",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "StatementWithholding",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "StatementTable",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "StatementTable",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "StatementSection",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "StatementSection",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Statements",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Statements",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "StatementItem",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "StatementItem",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Projects",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Projects",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Privilege",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Privilege",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "PercentageDetail",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "PercentageDetail",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Ledgers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Ledgers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "ExternalSuppliesItem",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "ExternalSuppliesItem",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DepartmentUser",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DepartmentUser",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Departments",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Departments",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Companies",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Companies",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "BoqTable",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "BoqTable",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "BoqSection",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "BoqSection",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Boqs",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Boqs",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "BoqItem",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "BoqItem",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "AwardTypes",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "AwardTypes",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "AdjustmentWithholding",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "AdjustmentWithholding",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Adjustments",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Adjustments",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "WorkTypes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "WorkTypes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "StatementWithholding",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "StatementWithholding",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "StatementTable",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "StatementTable",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "StatementSection",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "StatementSection",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "Statements",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "Statements",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "StatementItem",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "StatementItem",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "Projects",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "Projects",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "Privilege",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "Privilege",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "PercentageDetail",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "PercentageDetail",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "Ledgers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "Ledgers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "ExternalSuppliesItem",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "ExternalSuppliesItem",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "DepartmentUser",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "DepartmentUser",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "Departments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "Departments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "Companies",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "Companies",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "BoqTable",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "BoqTable",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "BoqSection",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "BoqSection",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "Boqs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "Boqs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "BoqItem",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "BoqItem",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "AwardTypes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "AwardTypes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "AdjustmentWithholding",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "AdjustmentWithholding",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "Adjustments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "Adjustments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
