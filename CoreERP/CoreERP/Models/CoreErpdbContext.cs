using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CoreERP.Models;

public partial class CoreErpdbContext : DbContext
{
    private readonly IConfiguration _configuration;
   
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
        optionsBuilder.UseSqlServer("Data Source=priyanka;Initial Catalog=CoreERPDB;Integrated Security=True;Trust Server Certificate=True");
    }
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    var connectionString = _configuration.GetConnectionString("defaultConnection");
    //    optionsBuilder.UseSqlServer(connectionString);
    //}
}
