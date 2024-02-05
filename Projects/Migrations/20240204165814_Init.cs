using System;
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
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstimatedPrice = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AwardTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classification",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CostCenters",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    ParentFullPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostCenters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CostCenters_CostCenters_ParentId",
                        column: x => x.ParentId,
                        principalTable: "CostCenters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ledgers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    ParentFullPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ledgers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ledgers_Ledgers_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Ledgers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MainBanks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainBanks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxAuthorities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxAuthorities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValueAddedTaxPercent = table.Column<double>(type: "float", nullable: false),
                    CommercialIndustrialTaxPercent = table.Column<double>(type: "float", nullable: false),
                    SelfEmploymentTaxPercent = table.Column<double>(type: "float", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankBranches",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainBankId = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankBranches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankBranches_MainBanks_MainBankId",
                        column: x => x.MainBankId,
                        principalTable: "MainBanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommercialRegister = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxCard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ElectronicInvoice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommercialIndustrialTaxFree = table.Column<bool>(type: "bit", nullable: false),
                    TaxAuthorityId = table.Column<long>(type: "bigint", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_TaxAuthorities_TaxAuthorityId",
                        column: x => x.TaxAuthorityId,
                        principalTable: "TaxAuthorities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DepartmentUser",
                columns: table => new
                {
                    DepartmentsId = table.Column<long>(type: "bigint", nullable: false),
                    UsersId = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkTypeId = table.Column<long>(type: "bigint", nullable: false),
                    CostCenterId = table.Column<long>(type: "bigint", nullable: false),
                    Sovereign = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    FundingType = table.Column<int>(type: "int", nullable: false),
                    AwardTypeId = table.Column<long>(type: "bigint", nullable: true),
                    CompanyId = table.Column<long>(type: "bigint", nullable: true),
                    OrderNumber = table.Column<int>(type: "int", nullable: true),
                    OrderDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    Duration_Years = table.Column<int>(type: "int", nullable: false),
                    Duration_Months = table.Column<int>(type: "int", nullable: false),
                    Duration_Days = table.Column<int>(type: "int", nullable: false),
                    ValueAddedTaxIncluded = table.Column<bool>(type: "bit", nullable: true),
                    AdvancePaymentPercentage = table.Column<double>(type: "float", nullable: true),
                    HandoverDate = table.Column<DateOnly>(type: "date", nullable: true),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    InitialDeliveryDate = table.Column<DateOnly>(type: "date", nullable: true),
                    InitialDeliverySigningDate = table.Column<DateOnly>(type: "date", nullable: true),
                    FinalDeliveryDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ContractPapersCount = table.Column<int>(type: "int", nullable: true),
                    ContractsCount = table.Column<int>(type: "int", nullable: true),
                    MainBankId = table.Column<long>(type: "bigint", nullable: true),
                    BankBranchId = table.Column<long>(type: "bigint", nullable: true),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxAuthorityId = table.Column<long>(type: "bigint", nullable: true),
                    FinalGuaranteeLetterExpiryDate = table.Column<DateOnly>(type: "date", nullable: true),
                    AdvancePaymentGuaranteeLetterExpiryDate = table.Column<DateOnly>(type: "date", nullable: true),
                    InsurancePolicyExpiryDate = table.Column<DateOnly>(type: "date", nullable: true),
                    WaivedToBank = table.Column<bool>(type: "bit", nullable: false),
                    AssigneeMainBankId = table.Column<long>(type: "bigint", nullable: true),
                    AssigneeBankBranchId = table.Column<long>(type: "bigint", nullable: true),
                    FromLedgerId = table.Column<long>(type: "bigint", nullable: true),
                    ToLedgerId = table.Column<long>(type: "bigint", nullable: true),
                    AdvancePaymentLedgerId = table.Column<long>(type: "bigint", nullable: true),
                    Approved = table.Column<bool>(type: "bit", nullable: false),
                    ApprovedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                        name: "FK_Projects_BankBranches_AssigneeBankBranchId",
                        column: x => x.AssigneeBankBranchId,
                        principalTable: "BankBranches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Projects_BankBranches_BankBranchId",
                        column: x => x.BankBranchId,
                        principalTable: "BankBranches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Projects_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_CostCenters_CostCenterId",
                        column: x => x.CostCenterId,
                        principalTable: "CostCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_Ledgers_AdvancePaymentLedgerId",
                        column: x => x.AdvancePaymentLedgerId,
                        principalTable: "Ledgers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Projects_Ledgers_FromLedgerId",
                        column: x => x.FromLedgerId,
                        principalTable: "Ledgers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Projects_Ledgers_ToLedgerId",
                        column: x => x.ToLedgerId,
                        principalTable: "Ledgers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Projects_MainBanks_AssigneeMainBankId",
                        column: x => x.AssigneeMainBankId,
                        principalTable: "MainBanks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Projects_MainBanks_MainBankId",
                        column: x => x.MainBankId,
                        principalTable: "MainBanks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Projects_TaxAuthorities_TaxAuthorityId",
                        column: x => x.TaxAuthorityId,
                        principalTable: "TaxAuthorities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Projects_WorkTypes_WorkTypeId",
                        column: x => x.WorkTypeId,
                        principalTable: "WorkTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Boqs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    PriceChangePercent = table.Column<double>(type: "float", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: false),
                    ApprovedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boqs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Boqs_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassificationProject",
                columns: table => new
                {
                    ClassificationsId = table.Column<long>(type: "bigint", nullable: false),
                    ProjectsId = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassificationProject", x => new { x.ClassificationsId, x.ProjectsId });
                    table.ForeignKey(
                        name: "FK_ClassificationProject_Classification_ClassificationsId",
                        column: x => x.ClassificationsId,
                        principalTable: "Classification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassificationProject_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModifiedEndDate",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<DateOnly>(type: "date", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModifiedEndDate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModifiedEndDate_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Privilege",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Privilege", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Privilege_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Statements",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    Index = table.Column<int>(type: "int", nullable: false),
                    PriceChangePercent = table.Column<double>(type: "float", nullable: false),
                    WorksDate = table.Column<DateOnly>(type: "date", nullable: false),
                    SubmissionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Final = table.Column<bool>(type: "bit", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    TotalWorks = table.Column<double>(type: "float", nullable: false),
                    TotalSupplies = table.Column<double>(type: "float", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "BoqDepartment",
                columns: table => new
                {
                    BoqId = table.Column<long>(type: "bigint", nullable: false),
                    DepartmentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoqDepartment", x => new { x.BoqId, x.DepartmentId });
                    table.ForeignKey(
                        name: "FK_BoqDepartment_Boqs_BoqId",
                        column: x => x.BoqId,
                        principalTable: "Boqs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoqTable",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoqId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    PriceChangePercent = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    WorkTypeId = table.Column<long>(type: "bigint", nullable: false),
                    IsPerformanceRate = table.Column<bool>(type: "bit", nullable: false),
                    CostCenterId = table.Column<long>(type: "bigint", nullable: false),
                    Sovereign = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_BoqTable_CostCenters_CostCenterId",
                        column: x => x.CostCenterId,
                        principalTable: "CostCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BoqTable_WorkTypes_WorkTypeId",
                        column: x => x.WorkTypeId,
                        principalTable: "WorkTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExternalSuppliesItem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SuppliesTableId = table.Column<long>(type: "bigint", nullable: false),
                    DepartmentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Index = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    PreviousQuantity = table.Column<double>(type: "float", nullable: false),
                    TotalQuantity = table.Column<double>(type: "float", nullable: false),
                    Percentage = table.Column<double>(type: "float", nullable: false),
                    CostCenterId = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatementId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalSuppliesItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExternalSuppliesItem_Statements_StatementId",
                        column: x => x.StatementId,
                        principalTable: "Statements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Settlements",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    StatementIndex = table.Column<int>(type: "int", nullable: false),
                    WorksDate = table.Column<DateOnly>(type: "date", nullable: false),
                    TotalWorks = table.Column<double>(type: "float", nullable: false),
                    TotalSupplies = table.Column<double>(type: "float", nullable: false),
                    PreviousTotalWorks = table.Column<double>(type: "float", nullable: false),
                    PreviousTotalSupplies = table.Column<double>(type: "float", nullable: false),
                    ServiceTax = table.Column<double>(type: "float", nullable: false),
                    SupervisionCommission = table.Column<double>(type: "float", nullable: false),
                    AdvancePaymentPercent = table.Column<double>(type: "float", nullable: false),
                    AdvancePaymentValue = table.Column<double>(type: "float", nullable: false),
                    CompletionGuaranteeValue = table.Column<double>(type: "float", nullable: false),
                    EngineersSyndicateValue = table.Column<double>(type: "float", nullable: false),
                    ApplicatorsSyndicateValue = table.Column<double>(type: "float", nullable: false),
                    RegularStampTax = table.Column<double>(type: "float", nullable: false),
                    AdditionalStampTax = table.Column<double>(type: "float", nullable: false),
                    ResourceDevelopmentTax = table.Column<double>(type: "float", nullable: false),
                    CommercialIndustrialTax = table.Column<double>(type: "float", nullable: false),
                    SelfEmploymentTax = table.Column<double>(type: "float", nullable: false),
                    ValueAddedTaxPercent = table.Column<double>(type: "float", nullable: false),
                    ValueAddedTax = table.Column<double>(type: "float", nullable: false),
                    WasteRemovalInsurance = table.Column<double>(type: "float", nullable: false),
                    TahyaMisrFundValue = table.Column<double>(type: "float", nullable: false),
                    ConractStampTax = table.Column<double>(type: "float", nullable: false),
                    ContractorsFederationValue = table.Column<double>(type: "float", nullable: false),
                    NetAmount = table.Column<double>(type: "float", nullable: false),
                    Submitted = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settlements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Settlements_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Settlements_Statements_Id",
                        column: x => x.Id,
                        principalTable: "Statements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StatementTable",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatementId = table.Column<long>(type: "bigint", nullable: false),
                    BoqTableId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceChangePercent = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    BoqTableType = table.Column<int>(type: "int", nullable: false),
                    CostCenterId = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatementId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatementWithholding", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatementWithholding_Statements_StatementId",
                        column: x => x.StatementId,
                        principalTable: "Statements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSubmission",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrivilegeType = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Approved = table.Column<bool>(type: "bit", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatementId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSubmission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSubmission_Statements_StatementId",
                        column: x => x.StatementId,
                        principalTable: "Statements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoqSection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkTypeId = table.Column<long>(type: "bigint", nullable: false),
                    IsPerformanceRate = table.Column<bool>(type: "bit", nullable: false),
                    CostCenterId = table.Column<long>(type: "bigint", nullable: false),
                    Sovereign = table.Column<bool>(type: "bit", nullable: false),
                    BoqTableId = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                        name: "FK_BoqSection_CostCenters_CostCenterId",
                        column: x => x.CostCenterId,
                        principalTable: "CostCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BoqSection_WorkTypes_WorkTypeId",
                        column: x => x.WorkTypeId,
                        principalTable: "WorkTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdvancePaymentDeductions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    SettlementId = table.Column<long>(type: "bigint", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvancePaymentDeductions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvancePaymentDeductions_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdvancePaymentDeductions_Settlements_SettlementId",
                        column: x => x.SettlementId,
                        principalTable: "Settlements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SettlementWithholding",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    FromStatement = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SettlementId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettlementWithholding", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SettlementWithholding_Settlements_SettlementId",
                        column: x => x.SettlementId,
                        principalTable: "Settlements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatementSection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoqSectionId = table.Column<long>(type: "bigint", nullable: false),
                    DepartmentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatementTableId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Index = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    WorkTypeId = table.Column<long>(type: "bigint", nullable: false),
                    IsPerformanceRate = table.Column<bool>(type: "bit", nullable: false),
                    CostCenterId = table.Column<long>(type: "bigint", nullable: false),
                    Sovereign = table.Column<bool>(type: "bit", nullable: false),
                    BoqSectionId = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_BoqItem_CostCenters_CostCenterId",
                        column: x => x.CostCenterId,
                        principalTable: "CostCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BoqItem_WorkTypes_WorkTypeId",
                        column: x => x.WorkTypeId,
                        principalTable: "WorkTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StatementItem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoqItemId = table.Column<long>(type: "bigint", nullable: false),
                    Index = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoqQuantity = table.Column<double>(type: "float", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    PreviousQuantity = table.Column<double>(type: "float", nullable: false),
                    TotalQuantity = table.Column<double>(type: "float", nullable: false),
                    Percentage = table.Column<double>(type: "float", nullable: false),
                    PreviousNetPrice = table.Column<double>(type: "float", nullable: false),
                    WorkTypeId = table.Column<long>(type: "bigint", nullable: false),
                    IsPerformanceRate = table.Column<bool>(type: "bit", nullable: false),
                    CostCenterId = table.Column<long>(type: "bigint", nullable: false),
                    Sovereign = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatementSectionId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "PercentageDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Percentage = table.Column<double>(type: "float", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatementItemId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "IX_AdvancePaymentDeductions_ProjectId",
                table: "AdvancePaymentDeductions",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvancePaymentDeductions_SettlementId",
                table: "AdvancePaymentDeductions",
                column: "SettlementId",
                unique: true,
                filter: "[SettlementId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BankBranches_MainBankId",
                table: "BankBranches",
                column: "MainBankId");

            migrationBuilder.CreateIndex(
                name: "IX_BoqItem_BoqSectionId",
                table: "BoqItem",
                column: "BoqSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_BoqItem_CostCenterId",
                table: "BoqItem",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_BoqItem_WorkTypeId",
                table: "BoqItem",
                column: "WorkTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Boqs_ProjectId",
                table: "Boqs",
                column: "ProjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoqSection_BoqTableId",
                table: "BoqSection",
                column: "BoqTableId");

            migrationBuilder.CreateIndex(
                name: "IX_BoqSection_CostCenterId",
                table: "BoqSection",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_BoqSection_WorkTypeId",
                table: "BoqSection",
                column: "WorkTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BoqTable_BoqId",
                table: "BoqTable",
                column: "BoqId");

            migrationBuilder.CreateIndex(
                name: "IX_BoqTable_CostCenterId",
                table: "BoqTable",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_BoqTable_WorkTypeId",
                table: "BoqTable",
                column: "WorkTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassificationProject_ProjectsId",
                table: "ClassificationProject",
                column: "ProjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_TaxAuthorityId",
                table: "Companies",
                column: "TaxAuthorityId");

            migrationBuilder.CreateIndex(
                name: "IX_CostCenters_ParentId",
                table: "CostCenters",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentUser_UsersId",
                table: "DepartmentUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalSuppliesItem_StatementId",
                table: "ExternalSuppliesItem",
                column: "StatementId");

            migrationBuilder.CreateIndex(
                name: "IX_Ledgers_ParentId",
                table: "Ledgers",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ModifiedEndDate_ProjectId",
                table: "ModifiedEndDate",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PercentageDetail_StatementItemId",
                table: "PercentageDetail",
                column: "StatementItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Privilege_ProjectId",
                table: "Privilege",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_AdvancePaymentLedgerId",
                table: "Projects",
                column: "AdvancePaymentLedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_AssigneeBankBranchId",
                table: "Projects",
                column: "AssigneeBankBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_AssigneeMainBankId",
                table: "Projects",
                column: "AssigneeMainBankId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_AwardTypeId",
                table: "Projects",
                column: "AwardTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_BankBranchId",
                table: "Projects",
                column: "BankBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CompanyId",
                table: "Projects",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CostCenterId",
                table: "Projects",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_FromLedgerId",
                table: "Projects",
                column: "FromLedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_MainBankId",
                table: "Projects",
                column: "MainBankId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_TaxAuthorityId",
                table: "Projects",
                column: "TaxAuthorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ToLedgerId",
                table: "Projects",
                column: "ToLedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_WorkTypeId",
                table: "Projects",
                column: "WorkTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Settlements_ProjectId",
                table: "Settlements",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SettlementWithholding_SettlementId",
                table: "SettlementWithholding",
                column: "SettlementId");

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

            migrationBuilder.CreateIndex(
                name: "IX_UserSubmission_StatementId",
                table: "UserSubmission",
                column: "StatementId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvancePaymentDeductions");

            migrationBuilder.DropTable(
                name: "BoqDepartment");

            migrationBuilder.DropTable(
                name: "BoqItem");

            migrationBuilder.DropTable(
                name: "ClassificationProject");

            migrationBuilder.DropTable(
                name: "DepartmentUser");

            migrationBuilder.DropTable(
                name: "ExternalSuppliesItem");

            migrationBuilder.DropTable(
                name: "ModifiedEndDate");

            migrationBuilder.DropTable(
                name: "PercentageDetail");

            migrationBuilder.DropTable(
                name: "Privilege");

            migrationBuilder.DropTable(
                name: "SettlementWithholding");

            migrationBuilder.DropTable(
                name: "StatementWithholding");

            migrationBuilder.DropTable(
                name: "UserSubmission");

            migrationBuilder.DropTable(
                name: "BoqSection");

            migrationBuilder.DropTable(
                name: "Classification");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "StatementItem");

            migrationBuilder.DropTable(
                name: "Settlements");

            migrationBuilder.DropTable(
                name: "BoqTable");

            migrationBuilder.DropTable(
                name: "StatementSection");

            migrationBuilder.DropTable(
                name: "Boqs");

            migrationBuilder.DropTable(
                name: "StatementTable");

            migrationBuilder.DropTable(
                name: "Statements");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "AwardTypes");

            migrationBuilder.DropTable(
                name: "BankBranches");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "CostCenters");

            migrationBuilder.DropTable(
                name: "Ledgers");

            migrationBuilder.DropTable(
                name: "WorkTypes");

            migrationBuilder.DropTable(
                name: "MainBanks");

            migrationBuilder.DropTable(
                name: "TaxAuthorities");
        }
    }
}
