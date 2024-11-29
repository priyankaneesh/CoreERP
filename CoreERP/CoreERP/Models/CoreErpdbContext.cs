using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreERP.Models;

public partial class CoreErpdbContext : DbContext
{
    public CoreErpdbContext()
    {
    }

    public CoreErpdbContext(DbContextOptions<CoreErpdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    public virtual DbSet<PurchaseItem> PurchaseItems { get; set; }

    public virtual DbSet<PurchaseReturn> PurchaseReturns { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SalesItem> SalesItems { get; set; }

    public virtual DbSet<SalesReturn> SalesReturns { get; set; }

    public virtual DbSet<StatusCode> StatusCodes { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=priyanka;Initial Catalog=CoreERPDB;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PK__Company__2D971C4C7E143712");

            entity.ToTable("Company");

            entity.Property(e => e.CompanyId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("CompanyID");
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Capital).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Gstnumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("GSTNumber");
            entity.Property(e => e.Income).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Website)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04FF1B8F4C98F");

            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("EmployeeID");
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Doj).HasColumnName("DOJ");
            entity.Property(e => e.Education)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Position)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SalaryPackage).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.StatusCodeNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.StatusCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_StatusCodes");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__Inventor__727E83EB40B44DDB");

            entity.ToTable("Inventory");

            entity.Property(e => e.ItemId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ItemID");
            entity.Property(e => e.BatchNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CostPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ItemCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ItemName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SellingPrice).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.PurchaseId).HasName("PK__Purchase__6B0A6BDE50C65ED0");

            entity.ToTable("Purchase");

            entity.Property(e => e.PurchaseId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("PurchaseID");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.VendorId).HasColumnName("VendorID");

            entity.HasOne(d => d.Vendor).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.VendorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Purchase_Vendor");
        });

        modelBuilder.Entity<PurchaseItem>(entity =>
        {
            entity.HasKey(e => e.PurchaseItemId).HasName("PK__Purchase__B48BB6A790DF0D95");

            entity.ToTable("PurchaseItem");

            entity.Property(e => e.PurchaseItemId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("PurchaseItemID");
            entity.Property(e => e.BatchNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.Mrp)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("MRP");
            entity.Property(e => e.PurchaseId).HasColumnName("PurchaseID");
            entity.Property(e => e.SellingCost).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Item).WithMany(p => p.PurchaseItems)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PurchaseItem_Inventory");

            entity.HasOne(d => d.Purchase).WithMany(p => p.PurchaseItems)
                .HasForeignKey(d => d.PurchaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PurchaseItem_Purchase");
        });

        modelBuilder.Entity<PurchaseReturn>(entity =>
        {
            entity.HasKey(e => e.ReturnId).HasName("PK__Purchase__F445E98832D6FEA9");

            entity.ToTable("PurchaseReturn");

            entity.Property(e => e.ReturnId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ReturnID");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.PurchaseId).HasColumnName("PurchaseID");
            entity.Property(e => e.ReturnDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ReturnReason)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Item).WithMany(p => p.PurchaseReturns)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PurchaseReturn_Inventory");

            entity.HasOne(d => d.Purchase).WithMany(p => p.PurchaseReturns)
                .HasForeignKey(d => d.PurchaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PurchaseReturn_Purchase");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.SalesId).HasName("PK__Sales__C952FB12091B4597");

            entity.Property(e => e.SalesId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("SalesID");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<SalesItem>(entity =>
        {
            entity.HasKey(e => e.SalesItemId).HasName("PK__SalesIte__B97422E118EE9362");

            entity.ToTable("SalesItem");

            entity.Property(e => e.SalesItemId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("SalesItemID");
            entity.Property(e => e.BatchNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.SalesId).HasColumnName("SalesID");
            entity.Property(e => e.SellingPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Item).WithMany(p => p.SalesItems)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesItem_Inventory");

            entity.HasOne(d => d.Sales).WithMany(p => p.SalesItems)
                .HasForeignKey(d => d.SalesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesItem_Sales");
        });

        modelBuilder.Entity<SalesReturn>(entity =>
        {
            entity.HasKey(e => e.ReturnId).HasName("PK__SalesRet__F445E9881B0A4543");

            entity.ToTable("SalesReturn");

            entity.Property(e => e.ReturnId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ReturnID");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.ReturnDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ReturnReason)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SalesId).HasColumnName("SalesID");

            entity.HasOne(d => d.Item).WithMany(p => p.SalesReturns)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesReturn_Inventory");

            entity.HasOne(d => d.Sales).WithMany(p => p.SalesReturns)
                .HasForeignKey(d => d.SalesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesReturn_Sales");
        });

        modelBuilder.Entity<StatusCode>(entity =>
        {
            entity.HasKey(e => e.StatusCode1).HasName("PK__StatusCo__6A7B44FD21A29455");

            entity.Property(e => e.StatusCode1)
                .ValueGeneratedNever()
                .HasColumnName("StatusCode");
            entity.Property(e => e.StatusDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.HasKey(e => e.VendorId).HasName("PK__Vendor__FC8618D3B656F965");

            entity.ToTable("Vendor");

            entity.Property(e => e.VendorId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("VendorID");
            entity.Property(e => e.AccountNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Gstnumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("GSTNumber");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Website)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.StatusCodeNavigation).WithMany(p => p.Vendors)
                .HasForeignKey(d => d.StatusCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vendor_StatusCodes");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
