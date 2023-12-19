﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NUCA.Projects.Data;

#nullable disable

namespace NUCA.Projects.Data.Migrations
{
    [DbContext(typeof(ProjectsDatabaseContext))]
    partial class ProjectsDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

            modelBuilder.Entity("DepartmentUser", b =>
                {
                    b.Property<int>("DepartmentsId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("UsersId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("TEXT");

                    b.HasKey("DepartmentsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("DepartmentUser");
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.Adjustments.Adjustment", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<double>("AdditionalStampDuty")
                        .HasColumnType("REAL");

                    b.Property<double>("AdvancedPaymentPercent")
                        .HasColumnType("REAL");

                    b.Property<double>("AdvancedPaymentValue")
                        .HasColumnType("REAL");

                    b.Property<double>("ApplicatorsSyndicateValue")
                        .HasColumnType("REAL");

                    b.Property<double>("CommercialIndustrialTax")
                        .HasColumnType("REAL");

                    b.Property<double>("CompletionGuaranteeValue")
                        .HasColumnType("REAL");

                    b.Property<double>("ConractStampDuty")
                        .HasColumnType("REAL");

                    b.Property<double>("ContractorsFederationValue")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<double>("EngineersSyndicateValue")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<double>("PreviousTotalSupplies")
                        .HasColumnType("REAL");

                    b.Property<double>("PreviousTotalWorks")
                        .HasColumnType("REAL");

                    b.Property<long>("ProjectId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("RegularStampDuty")
                        .HasColumnType("REAL");

                    b.Property<double>("ServiceTax")
                        .HasColumnType("REAL");

                    b.Property<int>("StatementIndex")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Submitted")
                        .HasColumnType("INTEGER");

                    b.Property<double>("TahyaMisrFundValue")
                        .HasColumnType("REAL");

                    b.Property<double>("Total")
                        .HasColumnType("REAL");

                    b.Property<double>("TotalSupplies")
                        .HasColumnType("REAL");

                    b.Property<double>("TotalWorks")
                        .HasColumnType("REAL");

                    b.Property<double>("ValueAddedTax")
                        .HasColumnType("REAL");

                    b.Property<double>("ValueAddedTaxPercent")
                        .HasColumnType("REAL");

                    b.Property<double>("WasteRemovalInsurance")
                        .HasColumnType("REAL");

                    b.Property<DateOnly>("WorksDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Adjustments");
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.Adjustments.AdjustmentWithholding", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("AdjustmentId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<bool>("FromStatement")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Value")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("AdjustmentId");

                    b.ToTable("AdjustmentWithholding");
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.Boqs.Boq", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<double>("PriceChangePercent")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Boqs");
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.Boqs.BoqItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("BoqSectionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Index")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<double>("Quantity")
                        .HasColumnType("REAL");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("BoqSectionId");

                    b.ToTable("BoqItem");
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.Boqs.BoqSection", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("BoqTableId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("DepartmentId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BoqTableId");

                    b.ToTable("BoqSection");
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.Boqs.BoqTable", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("BoqId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("PriceChangePercent")
                        .HasColumnType("REAL");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BoqId");

                    b.ToTable("BoqTable");
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.Companies.Company", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("CommercialIndustrialTaxFree")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CommercialRegister")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("ElectronicInvoice")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Fax")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TaxCard")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.Departments.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.FinanceAdmin.AwardType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<bool>("EstimatedPrice")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AwardTypes");
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.FinanceAdmin.WorkType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("ValueAddedTaxPercent")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("WorkTypes");
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.Ledgers.Ledger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int>("Index")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Ledgers");
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.Projects.Privilege", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<long>("ProjectId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Privilege");
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.Projects.Project", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double?>("AdvancedPaymentPercentage")
                        .HasColumnType("REAL");

                    b.Property<int?>("AwardTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("CompanyId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("DepartmentId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateOnly?>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly?>("FinalDeliveryDate")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly?>("HandoverDate")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly?>("InitialDeliveryDate")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly?>("InitialDeliverySigningDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateOnly?>("OrderDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("OrderNumber")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("Price")
                        .HasColumnType("REAL");

                    b.Property<DateOnly?>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TotalContractPapers")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TypeId")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("ValueAddedTaxIncluded")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AwardTypeId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("TypeId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.Statements.ExternalSuppliesItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Index")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<double>("Percentage")
                        .HasColumnType("REAL");

                    b.Property<double>("PreviousQuantity")
                        .HasColumnType("REAL");

                    b.Property<long>("StatementId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("SuppliesTableId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("TotalQuantity")
                        .HasColumnType("REAL");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("StatementId");

                    b.ToTable("ExternalSuppliesItem");
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.Statements.PercentageDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT");

                    b.Property<double>("Percentage")
                        .HasColumnType("REAL");

                    b.Property<double>("Quantity")
                        .HasColumnType("REAL");

                    b.Property<long>("StatementItemId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("StatementItemId");

                    b.ToTable("PercentageDetail");
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.Statements.Statement", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Final")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Index")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<double>("PriceChangePercent")
                        .HasColumnType("REAL");

                    b.Property<long>("ProjectId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("State")
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("SubmissionDate")
                        .HasColumnType("TEXT");

                    b.Property<double>("TotalSupplies")
                        .HasColumnType("REAL");

                    b.Property<double>("TotalWorks")
                        .HasColumnType("REAL");

                    b.Property<DateOnly>("WorksDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Statements");
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.Statements.StatementItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("BoqItemId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("BoqQuantity")
                        .HasColumnType("REAL");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Index")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<double>("Percentage")
                        .HasColumnType("REAL");

                    b.Property<double>("PreviousQuantity")
                        .HasColumnType("REAL");

                    b.Property<long>("StatementSectionId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("TotalQuantity")
                        .HasColumnType("REAL");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("StatementSectionId");

                    b.ToTable("StatementItem");
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.Statements.StatementSection", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("BoqSectionId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("DepartmentId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("StatementTableId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("StatementTableId");

                    b.ToTable("StatementSection");
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.Statements.StatementTable", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("BoqTableId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BoqTableType")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("PriceChangePercent")
                        .HasColumnType("REAL");

                    b.Property<long>("StatementId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("StatementId");

                    b.ToTable("StatementTable");
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.Statements.StatementWithholding", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("StatementId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Value")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("StatementId");

                    b.ToTable("StatementWithholding");
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.Users.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DepartmentUser", b =>
                {
                    b.HasOne("NUCA.Projects.Domain.Entities.Departments.Department", null)
                        .WithMany()
                        .HasForeignKey("DepartmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NUCA.Projects.Domain.Entities.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.Adjustments.Adjustment", b =>
                {
                    b.HasOne("NUCA.Projects.Domain.Entities.Statements.Statement", null)
                        .WithOne()
                        .HasForeignKey("NUCA.Projects.Domain.Entities.Adjustments.Adjustment", "Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("NUCA.Projects.Domain.Entities.Projects.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.Adjustments.AdjustmentWithholding", b =>
                {
                    b.HasOne("NUCA.Projects.Domain.Entities.Adjustments.Adjustment", null)
                        .WithMany("Withholdings")
                        .HasForeignKey("AdjustmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.Boqs.Boq", b =>
                {
                    b.HasOne("NUCA.Projects.Domain.Entities.Projects.Project", null)
                        .WithOne()
                        .HasForeignKey("NUCA.Projects.Domain.Entities.Boqs.Boq", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.Boqs.BoqItem", b =>
                {
                    b.HasOne("NUCA.Projects.Domain.Entities.Boqs.BoqSection", null)
                        .WithMany("Items")
                        .HasForeignKey("BoqSectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.Boqs.BoqSection", b =>
                {
                    b.HasOne("NUCA.Projects.Domain.Entities.Boqs.BoqTable", null)
                        .WithMany("Sections")
                        .HasForeignKey("BoqTableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.Boqs.BoqTable", b =>
                {
                    b.HasOne("NUCA.Projects.Domain.Entities.Boqs.Boq", null)
                        .WithMany("Tables")
                        .HasForeignKey("BoqId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.Projects.Privilege", b =>
                {
                    b.HasOne("NUCA.Projects.Domain.Entities.Projects.Project", null)
                        .WithMany("Privileges")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.Projects.Project", b =>
                {
                    b.HasOne("NUCA.Projects.Domain.Entities.FinanceAdmin.AwardType", "AwardType")
                        .WithMany()
                        .HasForeignKey("AwardTypeId");

                    b.HasOne("NUCA.Projects.Domain.Entities.Companies.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NUCA.Projects.Domain.Entities.FinanceAdmin.WorkType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsMany("NUCA.Projects.Domain.Entities.Shared.Date", "ModifiedEndDates", b1 =>
                        {
                            b1.Property<long>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("INTEGER");

                            b1.Property<long>("ProjectId")
                                .HasColumnType("INTEGER");

                            b1.Property<DateOnly>("Value")
                                .HasColumnType("TEXT");

                            b1.HasKey("Id");

                            b1.HasIndex("ProjectId");

                            b1.ToTable("EndDates", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("ProjectId");
                        });

                    b.OwnsOne("NUCA.Projects.Domain.Entities.Shared.Duration", "Duration", b1 =>
                        {
                            b1.Property<long>("ProjectId")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("Days")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("Months")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("Years")
                                .HasColumnType("INTEGER");

                            b1.HasKey("ProjectId");

                            b1.ToTable("Projects");

                            b1.WithOwner()
                                .HasForeignKey("ProjectId");
                        });

                    b.Navigation("AwardType");

                    b.Navigation("Company");

                    b.Navigation("Duration")
                        .IsRequired();

                    b.Navigation("ModifiedEndDates");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.Statements.ExternalSuppliesItem", b =>
                {
                    b.HasOne("NUCA.Projects.Domain.Entities.Statements.Statement", null)
                        .WithMany("ExternalSuppliesItems")
                        .HasForeignKey("StatementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.Statements.PercentageDetail", b =>
                {
                    b.HasOne("NUCA.Projects.Domain.Entities.Statements.StatementItem", null)
                        .WithMany("PercentageDetails")
                        .HasForeignKey("StatementItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.Statements.Statement", b =>
                {
                    b.HasOne("NUCA.Projects.Domain.Entities.Projects.Project", null)
                        .WithMany("Statements")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.Statements.StatementItem", b =>
                {
                    b.HasOne("NUCA.Projects.Domain.Entities.Statements.StatementSection", null)
                        .WithMany("Items")
                        .HasForeignKey("StatementSectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.Statements.StatementSection", b =>
                {
                    b.HasOne("NUCA.Projects.Domain.Entities.Statements.StatementTable", null)
                        .WithMany("Sections")
                        .HasForeignKey("StatementTableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.Statements.StatementTable", b =>
                {
                    b.HasOne("NUCA.Projects.Domain.Entities.Statements.Statement", null)
                        .WithMany("Tables")
                        .HasForeignKey("StatementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.Statements.StatementWithholding", b =>
                {
                    b.HasOne("NUCA.Projects.Domain.Entities.Statements.Statement", null)
                        .WithMany("Withholdings")
                        .HasForeignKey("StatementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.Adjustments.Adjustment", b =>
                {
                    b.Navigation("Withholdings");
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.Boqs.Boq", b =>
                {
                    b.Navigation("Tables");
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.Boqs.BoqSection", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.Boqs.BoqTable", b =>
                {
                    b.Navigation("Sections");
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.Projects.Project", b =>
                {
                    b.Navigation("Privileges");

                    b.Navigation("Statements");
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.Statements.Statement", b =>
                {
                    b.Navigation("ExternalSuppliesItems");

                    b.Navigation("Tables");

                    b.Navigation("Withholdings");
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.Statements.StatementItem", b =>
                {
                    b.Navigation("PercentageDetails");
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.Statements.StatementSection", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("NUCA.Projects.Domain.Entities.Statements.StatementTable", b =>
                {
                    b.Navigation("Sections");
                });
#pragma warning restore 612, 618
        }
    }
}
