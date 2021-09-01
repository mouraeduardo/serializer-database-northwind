using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace agoravai.Models
{
    public partial class AppDbcontext : DbContext
    {
        public AppDbcontext()
        {
        }

        public AppDbcontext(DbContextOptions<AppDbcontext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeTerritory> EmployeeTerritories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Territory> Territories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=C:\\Users\\eduar\\OneDrive\\Área de Trabalho\\agoravai\\Northwind.db;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasIndex(e => e.CategoryName, "CategoryName");

                entity.Property(e => e.CategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnType("nvarchar (15)");

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.Picture).HasColumnType("image");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.City, "City");

                entity.HasIndex(e => e.CompanyName, "CompanyNameCustomers");

                entity.HasIndex(e => e.PostalCode, "PostalCodeCustomers");

                entity.HasIndex(e => e.Region, "Region");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("nchar (5)")
                    .HasColumnName("CustomerID");

                entity.Property(e => e.Address).HasColumnType("nvarchar (60)");

                entity.Property(e => e.City).HasColumnType("nvarchar (15)");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnType("nvarchar (40)");

                entity.Property(e => e.ContactName).HasColumnType("nvarchar (30)");

                entity.Property(e => e.ContactTitle).HasColumnType("nvarchar (30)");

                entity.Property(e => e.Country).HasColumnType("nvarchar (15)");

                entity.Property(e => e.Fax).HasColumnType("nvarchar (24)");

                entity.Property(e => e.Phone).HasColumnType("nvarchar (24)");

                entity.Property(e => e.PostalCode).HasColumnType("nvarchar (10)");

                entity.Property(e => e.Region).HasColumnType("nvarchar (15)");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.LastName, "LastName");

                entity.HasIndex(e => e.PostalCode, "PostalCodeEmployees");

                entity.Property(e => e.EmployeeId)
                    .ValueGeneratedNever()
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.Address).HasColumnType("nvarchar (60)");

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.City).HasColumnType("nvarchar (15)");

                entity.Property(e => e.Country).HasColumnType("nvarchar (15)");

                entity.Property(e => e.Extension).HasColumnType("nvarchar (4)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("nvarchar (10)");

                entity.Property(e => e.HireDate).HasColumnType("datetime");

                entity.Property(e => e.HomePhone).HasColumnType("nvarchar (24)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("nvarchar (20)");

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.Property(e => e.Photo).HasColumnType("image");

                entity.Property(e => e.PhotoPath).HasColumnType("nvarchar (255)");

                entity.Property(e => e.PostalCode).HasColumnType("nvarchar (10)");

                entity.Property(e => e.Region).HasColumnType("nvarchar (15)");

                entity.Property(e => e.ReportsTo).HasColumnType("int");

                entity.Property(e => e.Title).HasColumnType("nvarchar (30)");

                entity.Property(e => e.TitleOfCourtesy).HasColumnType("nvarchar (25)");
            });

            modelBuilder.Entity<EmployeeTerritory>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.EmployeeId)
                    .HasColumnType("int")
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.TerritoryId)
                    .IsRequired()
                    .HasColumnType("nvarchar")
                    .HasColumnName("TerritoryID");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasIndex(e => e.CustomerId, "CustomerID");

                entity.HasIndex(e => e.CustomerId, "CustomersOrders");

                entity.HasIndex(e => e.EmployeeId, "EmployeeID");

                entity.HasIndex(e => e.EmployeeId, "EmployeesOrders");

                entity.HasIndex(e => e.OrderDate, "OrderDate");

                entity.HasIndex(e => e.ShipPostalCode, "ShipPostalCode");

                entity.HasIndex(e => e.ShippedDate, "ShippedDate");

                entity.HasIndex(e => e.ShipVia, "ShippersOrders");

                entity.Property(e => e.OrderId)
                    .ValueGeneratedNever()
                    .HasColumnName("OrderID");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("nchar (5)")
                    .HasColumnName("CustomerID");

                entity.Property(e => e.EmployeeId)
                    .HasColumnType("int")
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.Freight)
                    .HasColumnType("money")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.RequiredDate).HasColumnType("datetime");

                entity.Property(e => e.ShipAddress).HasColumnType("nvarchar (60)");

                entity.Property(e => e.ShipCity).HasColumnType("nvarchar (15)");

                entity.Property(e => e.ShipCountry).HasColumnType("nvarchar (15)");

                entity.Property(e => e.ShipName).HasColumnType("nvarchar (40)");

                entity.Property(e => e.ShipPostalCode).HasColumnType("nvarchar (10)");

                entity.Property(e => e.ShipRegion).HasColumnType("nvarchar (15)");

                entity.Property(e => e.ShipVia).HasColumnType("int");

                entity.Property(e => e.ShippedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmployeeId);

                entity.HasOne(d => d.ShipViaNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ShipVia);
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId });

                entity.ToTable("Order Details");

                entity.HasIndex(e => e.OrderId, "OrderID");

                entity.HasIndex(e => e.OrderId, "OrdersOrder_Details");

                entity.HasIndex(e => e.ProductId, "ProductID");

                entity.HasIndex(e => e.ProductId, "ProductsOrder_Details");

                entity.Property(e => e.OrderId)
                    .HasColumnType("int")
                    .HasColumnName("OrderID");

                entity.Property(e => e.ProductId)
                    .HasColumnType("int")
                    .HasColumnName("ProductID");

                entity.Property(e => e.Discount).HasColumnType("real");

                entity.Property(e => e.Quantity)
                    .HasColumnType("smallint")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.UnitPrice)
                    .IsRequired()
                    .HasColumnType("money")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.CategoryId, "CategoriesProducts");

                entity.HasIndex(e => e.CategoryId, "CategoryID");

                entity.HasIndex(e => e.ProductName, "ProductName");

                entity.HasIndex(e => e.SupplierId, "SupplierID");

                entity.HasIndex(e => e.SupplierId, "SuppliersProducts");

                entity.Property(e => e.ProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProductID");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("int")
                    .HasColumnName("CategoryID");

                entity.Property(e => e.Discontinued)
                    .IsRequired()
                    .HasColumnType("bit")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnType("nvarchar (40)");

                entity.Property(e => e.QuantityPerUnit).HasColumnType("nvarchar (20)");

                entity.Property(e => e.ReorderLevel)
                    .HasColumnType("smallint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SupplierId)
                    .HasColumnType("int")
                    .HasColumnName("SupplierID");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("money")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.UnitsInStock)
                    .HasColumnType("smallint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.UnitsOnOrder)
                    .HasColumnType("smallint")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId);

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SupplierId);
            });

            modelBuilder.Entity<Shipper>(entity =>
            {
                entity.Property(e => e.ShipperId)
                    .ValueGeneratedNever()
                    .HasColumnName("ShipperID");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnType("nvarchar (40)");

                entity.Property(e => e.Phone).HasColumnType("nvarchar (24)");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasIndex(e => e.CompanyName, "CompanyNameSuppliers");

                entity.HasIndex(e => e.PostalCode, "PostalCodeSuppliers");

                entity.Property(e => e.SupplierId)
                    .ValueGeneratedNever()
                    .HasColumnName("SupplierID");

                entity.Property(e => e.Address).HasColumnType("nvarchar (60)");

                entity.Property(e => e.City).HasColumnType("nvarchar (15)");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnType("nvarchar (40)");

                entity.Property(e => e.ContactName).HasColumnType("nvarchar (30)");

                entity.Property(e => e.ContactTitle).HasColumnType("nvarchar (30)");

                entity.Property(e => e.Country).HasColumnType("nvarchar (15)");

                entity.Property(e => e.Fax).HasColumnType("nvarchar (24)");

                entity.Property(e => e.HomePage).HasColumnType("ntext");

                entity.Property(e => e.Phone).HasColumnType("nvarchar (24)");

                entity.Property(e => e.PostalCode).HasColumnType("nvarchar (10)");

                entity.Property(e => e.Region).HasColumnType("nvarchar (15)");
            });

            modelBuilder.Entity<Territory>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.RegionId)
                    .HasColumnType("int")
                    .HasColumnName("RegionID");

                entity.Property(e => e.TerritoryDescription)
                    .IsRequired()
                    .HasColumnType("nchar");

                entity.Property(e => e.TerritoryId)
                    .IsRequired()
                    .HasColumnType("nvarchar")
                    .HasColumnName("TerritoryID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
