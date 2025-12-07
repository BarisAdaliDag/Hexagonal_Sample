using HexagonalSample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Persistence.EFData
{

    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppUserProfile> AppUserProfiles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // AppUser - AppUserProfile ilişkisi (One-to-One)
            modelBuilder.Entity<AppUser>()
                .HasOne(a => a.AppUserProfile)
                .WithOne(p => p.AppUser)
                .HasForeignKey<AppUserProfile>(p => p.Id);

            // Product - Category ilişkisi (Many-to-One)
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);

            // Order - AppUser ilişkisi (Many-to-One)
            modelBuilder.Entity<Order>()
                .HasOne(o => o.AppUser)
                .WithMany(a => a.Orders)
                .HasForeignKey(o => o.AppUserId)
                .OnDelete(DeleteBehavior.SetNull);

            // OrderDetail - Order ilişkisi (Many-to-One)
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // OrderDetail - Product ilişkisi (Many-to-One)
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(od => od.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
