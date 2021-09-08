using Microsoft.EntityFrameworkCore;

namespace Packt.Shared
{
  public class Northwind : DbContext
  {
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(
      DbContextOptionsBuilder optionsBuilder)
    {
      string path = System.IO.Path.Combine(
        System.Environment.CurrentDirectory, "Northwind.db");
        
      optionsBuilder.UseSqlite($"Filename={path}");
    }

    protected override void OnModelCreating(
      ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Category>()
        .Property(category => category.CategoryName)
        .IsRequired()
        .HasMaxLength(15);

      modelBuilder.Entity<Product>()
        .Property(product => product.Cost)
        .HasConversion<double>();
    }
  }
}