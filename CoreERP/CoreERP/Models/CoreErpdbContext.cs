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

    public virtual DbSet<Login> Login { get; set; }
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
    {
        optionsBuilder.UseSqlServer("Data Source=LAPTOP-5M9L3AJN\\MSSQLSERVER02;Initial Catalog=erp;Integrated Security=True;Trust Server Certificate=True");
    }
}
