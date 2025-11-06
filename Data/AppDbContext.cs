using EcommerceDelegates.Models;
using Microsoft.EntityFrameworkCore;
using OrderEvent.Models;

namespace OrderEvent.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<ItemOrder> ItemOrders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Stock> Stocks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId);

        modelBuilder.Entity<ItemOrder>()
            .HasOne(io => io.Order)
            .WithMany(o => o.ItemOrders)
            .HasForeignKey(io => io.OrderId);

        modelBuilder.Entity<ItemOrder>()
            .HasOne(io => io.Product)
            .WithMany(p => p.ItemOrders)
            .HasForeignKey(io => io.ProductId);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Invoice)
            .WithOne(i => i.Order)
            .HasForeignKey<Invoice>(i => i.OrderId);

        modelBuilder.Entity<Product>()
           .HasOne(o => o.Stock)
           .WithOne(i => i.Product)
           .HasForeignKey<Stock>(io => io.ProductId)
           .OnDelete(DeleteBehavior.Cascade);
    }
}
