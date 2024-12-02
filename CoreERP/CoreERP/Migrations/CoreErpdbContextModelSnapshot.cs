﻿// <auto-generated />
using System;
using CoreERP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CoreERP.Migrations
{
    [DbContext(typeof(CoreErpdbContext))]
    partial class CoreErpdbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CoreERP.Models.Company", b =>
                {
                    b.Property<Guid>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Capital")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gstnumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Income")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("LoginId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyId");

                    b.HasIndex("LoginId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("CoreERP.Models.Employee", b =>
                {
                    b.Property<Guid>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly?>("Doj")
                        .HasColumnType("date");

                    b.Property<string>("Education")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("SalaryPackage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("StatusCode")
                        .HasColumnType("int");

                    b.Property<int>("StatusCodeNavigationStatusCode1")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.HasIndex("StatusCodeNavigationStatusCode1");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("CoreERP.Models.Inventory", b =>
                {
                    b.Property<Guid>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BatchNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("CostPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateOnly?>("ExpiryDate")
                        .HasColumnType("date");

                    b.Property<string>("ItemCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal?>("SellingPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ItemId");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("CoreERP.Models.Login", b =>
                {
                    b.Property<int>("LoginId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoginId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LoginId");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("CoreERP.Models.Purchase", b =>
                {
                    b.Property<Guid>("PurchaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly?>("PurchaseDate")
                        .HasColumnType("date");

                    b.Property<decimal?>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("VendorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PurchaseId");

                    b.HasIndex("VendorId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("CoreERP.Models.PurchaseItem", b =>
                {
                    b.Property<Guid>("PurchaseItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BatchNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly?>("ExpiryDate")
                        .HasColumnType("date");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("Mrp")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("PurchaseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal?>("SellingCost")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("PurchaseItemId");

                    b.HasIndex("ItemId");

                    b.HasIndex("PurchaseId");

                    b.ToTable("PurchaseItems");
                });

            modelBuilder.Entity("CoreERP.Models.PurchaseReturn", b =>
                {
                    b.Property<Guid>("ReturnId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PurchaseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("ReturnDate")
                        .HasColumnType("date");

                    b.Property<string>("ReturnReason")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReturnId");

                    b.HasIndex("ItemId");

                    b.HasIndex("PurchaseId");

                    b.ToTable("PurchaseReturns");
                });

            modelBuilder.Entity("CoreERP.Models.Sale", b =>
                {
                    b.Property<Guid>("SalesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly?>("BillDate")
                        .HasColumnType("date");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("SalesId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("CoreERP.Models.SalesItem", b =>
                {
                    b.Property<Guid>("SalesItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BatchNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("SalesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("SellingPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("SalesItemId");

                    b.HasIndex("ItemId");

                    b.HasIndex("SalesId");

                    b.ToTable("SalesItems");
                });

            modelBuilder.Entity("CoreERP.Models.SalesReturn", b =>
                {
                    b.Property<Guid>("ReturnId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("ReturnDate")
                        .HasColumnType("date");

                    b.Property<string>("ReturnReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SalesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ReturnId");

                    b.HasIndex("ItemId");

                    b.HasIndex("SalesId");

                    b.ToTable("SalesReturns");
                });

            modelBuilder.Entity("CoreERP.Models.StatusCode", b =>
                {
                    b.Property<int>("StatusCode1")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusCode1"));

                    b.Property<string>("StatusDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusCode1");

                    b.ToTable("StatusCodes");
                });

            modelBuilder.Entity("CoreERP.Models.Vendor", b =>
                {
                    b.Property<Guid>("VendorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gstnumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusCode")
                        .HasColumnType("int");

                    b.Property<int>("StatusCodeNavigationStatusCode1")
                        .HasColumnType("int");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VendorId");

                    b.HasIndex("StatusCodeNavigationStatusCode1");

                    b.ToTable("Vendors");
                });

            modelBuilder.Entity("CoreERP.Models.Company", b =>
                {
                    b.HasOne("CoreERP.Models.Login", "Login")
                        .WithMany()
                        .HasForeignKey("LoginId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Login");
                });

            modelBuilder.Entity("CoreERP.Models.Employee", b =>
                {
                    b.HasOne("CoreERP.Models.StatusCode", "StatusCodeNavigation")
                        .WithMany("Employees")
                        .HasForeignKey("StatusCodeNavigationStatusCode1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StatusCodeNavigation");
                });

            modelBuilder.Entity("CoreERP.Models.Purchase", b =>
                {
                    b.HasOne("CoreERP.Models.Vendor", "Vendor")
                        .WithMany("Purchases")
                        .HasForeignKey("VendorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("CoreERP.Models.PurchaseItem", b =>
                {
                    b.HasOne("CoreERP.Models.Inventory", "Item")
                        .WithMany("PurchaseItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoreERP.Models.Purchase", "Purchase")
                        .WithMany("PurchaseItems")
                        .HasForeignKey("PurchaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Purchase");
                });

            modelBuilder.Entity("CoreERP.Models.PurchaseReturn", b =>
                {
                    b.HasOne("CoreERP.Models.Inventory", "Item")
                        .WithMany("PurchaseReturns")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoreERP.Models.Purchase", "Purchase")
                        .WithMany("PurchaseReturns")
                        .HasForeignKey("PurchaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Purchase");
                });

            modelBuilder.Entity("CoreERP.Models.SalesItem", b =>
                {
                    b.HasOne("CoreERP.Models.Inventory", "Item")
                        .WithMany("SalesItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoreERP.Models.Sale", "Sales")
                        .WithMany("SalesItems")
                        .HasForeignKey("SalesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Sales");
                });

            modelBuilder.Entity("CoreERP.Models.SalesReturn", b =>
                {
                    b.HasOne("CoreERP.Models.Inventory", "Item")
                        .WithMany("SalesReturns")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoreERP.Models.Sale", "Sales")
                        .WithMany("SalesReturns")
                        .HasForeignKey("SalesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Sales");
                });

            modelBuilder.Entity("CoreERP.Models.Vendor", b =>
                {
                    b.HasOne("CoreERP.Models.StatusCode", "StatusCodeNavigation")
                        .WithMany("Vendors")
                        .HasForeignKey("StatusCodeNavigationStatusCode1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StatusCodeNavigation");
                });

            modelBuilder.Entity("CoreERP.Models.Inventory", b =>
                {
                    b.Navigation("PurchaseItems");

                    b.Navigation("PurchaseReturns");

                    b.Navigation("SalesItems");

                    b.Navigation("SalesReturns");
                });

            modelBuilder.Entity("CoreERP.Models.Purchase", b =>
                {
                    b.Navigation("PurchaseItems");

                    b.Navigation("PurchaseReturns");
                });

            modelBuilder.Entity("CoreERP.Models.Sale", b =>
                {
                    b.Navigation("SalesItems");

                    b.Navigation("SalesReturns");
                });

            modelBuilder.Entity("CoreERP.Models.StatusCode", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Vendors");
                });

            modelBuilder.Entity("CoreERP.Models.Vendor", b =>
                {
                    b.Navigation("Purchases");
                });
#pragma warning restore 612, 618
        }
    }
}
