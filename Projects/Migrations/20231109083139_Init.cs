﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NUCA.Projects.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AwardTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    EstimatedPrice = table.Column<bool>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AwardTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CommercialIndustrialTaxFree = table.Column<bool>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ValueAddedTaxPercent = table.Column<double>(type: "REAL", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentUser",
                columns: table => new
                {
                    DepartmentsId = table.Column<int>(type: "INTEGER", nullable: false),
                    UsersId = table.Column<long>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentUser", x => new { x.DepartmentsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_DepartmentUser_Departments_DepartmentsId",
                        column: x => x.DepartmentsId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    DepartmentId = table.Column<int>(type: "INTEGER", nullable: false),
                    TypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    AwardTypeId = table.Column<int>(type: "INTEGER", nullable: true),
                    CompanyId = table.Column<long>(type: "INTEGER", nullable: true),
                    OrderNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    OrderDate = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    Price = table.Column<double>(type: "REAL", nullable: true),
                    Duration_Years = table.Column<int>(type: "INTEGER", nullable: false),
                    Duration_Months = table.Column<int>(type: "INTEGER", nullable: false),
                    Duration_Days = table.Column<int>(type: "INTEGER", nullable: false),
                    ValueAddedTaxIncluded = table.Column<bool>(type: "INTEGER", nullable: true),
                    AdvancedPaymentPercentage = table.Column<double>(type: "REAL", nullable: true),
                    HandoverDate = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    StartDate = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    EndDate = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    InitialDeliveryDate = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    InitialDeliverySigningDate = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    FinalDeliveryDate = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    TotalContractPapers = table.Column<int>(type: "INTEGER", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_AwardTypes_AwardTypeId",
                        column: x => x.AwardTypeId,
                        principalTable: "AwardTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Projects_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_WorkTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "WorkTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Boqs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false),
                    PriceChangePercent = table.Column<double>(type: "REAL", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boqs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Boqs_Projects_Id",
                        column: x => x.Id,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EndDates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    ProjectId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EndDates_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Statements",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProjectId = table.Column<long>(type: "INTEGER", nullable: false),
                    Index = table.Column<int>(type: "INTEGER", nullable: false),
                    PriceChangePercent = table.Column<double>(type: "REAL", nullable: false),
                    WorksDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    SubmissionDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Final = table.Column<bool>(type: "INTEGER", nullable: false),
                    State = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalWorks = table.Column<double>(type: "REAL", nullable: false),
                    TotalSupplies = table.Column<double>(type: "REAL", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statements_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BoqTable",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Count = table.Column<int>(type: "INTEGER", nullable: false),
                    PriceChangePercent = table.Column<double>(type: "REAL", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    BoqId = table.Column<long>(type: "INTEGER", nullable: true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoqTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoqTable_Boqs_BoqId",
                        column: x => x.BoqId,
                        principalTable: "Boqs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adjustments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false),
                    ProjectId = table.Column<long>(type: "INTEGER", nullable: false),
                    StatementIndex = table.Column<int>(type: "INTEGER", nullable: false),
                    WorksDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    TotalWorks = table.Column<double>(type: "REAL", nullable: false),
                    TotalSupplies = table.Column<double>(type: "REAL", nullable: false),
                    PreviousTotalWorks = table.Column<double>(type: "REAL", nullable: false),
                    PreviousTotalSupplies = table.Column<double>(type: "REAL", nullable: false),
                    ServiceTax = table.Column<double>(type: "REAL", nullable: false),
                    AdvancedPaymentPercent = table.Column<double>(type: "REAL", nullable: false),
                    AdvancedPaymentValue = table.Column<double>(type: "REAL", nullable: false),
                    CompletionGuaranteeValue = table.Column<double>(type: "REAL", nullable: false),
                    EngineersSyndicateValue = table.Column<double>(type: "REAL", nullable: false),
                    ApplicatorsSyndicateValue = table.Column<double>(type: "REAL", nullable: false),
                    RegularStampDuty = table.Column<double>(type: "REAL", nullable: false),
                    AdditionalStampDuty = table.Column<double>(type: "REAL", nullable: false),
                    CommercialIndustrialTax = table.Column<double>(type: "REAL", nullable: false),
                    ValueAddedTaxPercent = table.Column<double>(type: "REAL", nullable: false),
                    ValueAddedTax = table.Column<double>(type: "REAL", nullable: false),
                    WasteRemovalInsurance = table.Column<double>(type: "REAL", nullable: false),
                    ConractStampDuty = table.Column<double>(type: "REAL", nullable: false),
                    ContractorsFederationValue = table.Column<double>(type: "REAL", nullable: false),
                    Total = table.Column<double>(type: "REAL", nullable: false),
                    Submitted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adjustments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adjustments_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Adjustments_Statements_Id",
                        column: x => x.Id,
                        principalTable: "Statements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StatementTable",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StatementId = table.Column<long>(type: "INTEGER", nullable: false),
                    BoqTableId = table.Column<long>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PriceChangePercent = table.Column<double>(type: "REAL", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    BoqTableType = table.Column<int>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatementTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatementTable_Statements_StatementId",
                        column: x => x.StatementId,
                        principalTable: "Statements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatementWithholding",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<double>(type: "REAL", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StatementId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatementWithholding", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatementWithholding_Statements_StatementId",
                        column: x => x.StatementId,
                        principalTable: "Statements",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BoqSection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    DepartmentId = table.Column<int>(type: "INTEGER", nullable: false),
                    BoqTableId = table.Column<long>(type: "INTEGER", nullable: true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoqSection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoqSection_BoqTable_BoqTableId",
                        column: x => x.BoqTableId,
                        principalTable: "BoqTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoqSection_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdjustmentWithholding",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<double>(type: "REAL", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    FromStatement = table.Column<bool>(type: "INTEGER", nullable: false),
                    AdjustmentId = table.Column<long>(type: "INTEGER", nullable: true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdjustmentWithholding", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdjustmentWithholding_Adjustments_AdjustmentId",
                        column: x => x.AdjustmentId,
                        principalTable: "Adjustments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatementSection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BoqSectionId = table.Column<long>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StatementTableId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatementSection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatementSection_StatementTable_StatementTableId",
                        column: x => x.StatementTableId,
                        principalTable: "StatementTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoqItem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Index = table.Column<string>(type: "TEXT", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    Unit = table.Column<string>(type: "TEXT", nullable: false),
                    Quantity = table.Column<double>(type: "REAL", nullable: false),
                    UnitPrice = table.Column<double>(type: "REAL", nullable: false),
                    BoqSectionId = table.Column<long>(type: "INTEGER", nullable: true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoqItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoqItem_BoqSection_BoqSectionId",
                        column: x => x.BoqSectionId,
                        principalTable: "BoqSection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatementItem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BoqItemId = table.Column<long>(type: "INTEGER", nullable: false),
                    Index = table.Column<string>(type: "TEXT", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    Unit = table.Column<string>(type: "TEXT", nullable: false),
                    Quantity = table.Column<double>(type: "REAL", nullable: false),
                    UnitPrice = table.Column<double>(type: "REAL", nullable: false),
                    PreviousQuantity = table.Column<double>(type: "REAL", nullable: false),
                    TotalQuantity = table.Column<double>(type: "REAL", nullable: false),
                    Percentage = table.Column<double>(type: "REAL", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<long>(type: "INTEGER", nullable: true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StatementSectionId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatementItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatementItem_StatementSection_StatementSectionId",
                        column: x => x.StatementSectionId,
                        principalTable: "StatementSection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adjustments_ProjectId",
                table: "Adjustments",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_AdjustmentWithholding_AdjustmentId",
                table: "AdjustmentWithholding",
                column: "AdjustmentId");

            migrationBuilder.CreateIndex(
                name: "IX_BoqItem_BoqSectionId",
                table: "BoqItem",
                column: "BoqSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_BoqSection_BoqTableId",
                table: "BoqSection",
                column: "BoqTableId");

            migrationBuilder.CreateIndex(
                name: "IX_BoqSection_DepartmentId",
                table: "BoqSection",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_BoqTable_BoqId",
                table: "BoqTable",
                column: "BoqId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentUser_UsersId",
                table: "DepartmentUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_EndDates_ProjectId",
                table: "EndDates",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_AwardTypeId",
                table: "Projects",
                column: "AwardTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CompanyId",
                table: "Projects",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_DepartmentId",
                table: "Projects",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_TypeId",
                table: "Projects",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StatementItem_StatementSectionId",
                table: "StatementItem",
                column: "StatementSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Statements_ProjectId",
                table: "Statements",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_StatementSection_StatementTableId",
                table: "StatementSection",
                column: "StatementTableId");

            migrationBuilder.CreateIndex(
                name: "IX_StatementTable_StatementId",
                table: "StatementTable",
                column: "StatementId");

            migrationBuilder.CreateIndex(
                name: "IX_StatementWithholding_StatementId",
                table: "StatementWithholding",
                column: "StatementId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdjustmentWithholding");

            migrationBuilder.DropTable(
                name: "BoqItem");

            migrationBuilder.DropTable(
                name: "DepartmentUser");

            migrationBuilder.DropTable(
                name: "EndDates");

            migrationBuilder.DropTable(
                name: "StatementItem");

            migrationBuilder.DropTable(
                name: "StatementWithholding");

            migrationBuilder.DropTable(
                name: "Adjustments");

            migrationBuilder.DropTable(
                name: "BoqSection");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "StatementSection");

            migrationBuilder.DropTable(
                name: "BoqTable");

            migrationBuilder.DropTable(
                name: "StatementTable");

            migrationBuilder.DropTable(
                name: "Boqs");

            migrationBuilder.DropTable(
                name: "Statements");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "AwardTypes");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "WorkTypes");
        }
    }
}
