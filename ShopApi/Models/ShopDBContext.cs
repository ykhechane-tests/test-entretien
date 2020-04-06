using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ShopApi.Models
{
    public partial class ShopDBContext : DbContext
    {
        public ShopDBContext()
        {
        }

        public ShopDBContext(DbContextOptions<ShopDBContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }
        public virtual DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Customer");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderItem_Order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderItem_Product");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });



            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = 1, CreationDate = DateTime.Now, Name = "IMac", Price = 2500, Stock = 10 },
                new Product() { Id = 2, CreationDate = DateTime.Now, Name = "Iphone", Price = 800, Stock = 150 },
                new Product() { Id = 3, CreationDate = DateTime.Now, Name = "Ipad", Price = 500, Stock = 88 },
                new Product() { Id = 4, CreationDate = DateTime.Now, Name = "Casque Bose", Price = 400, Stock = 2 }
                );            

            modelBuilder.Entity<Customer>().HasData(
                new Customer() { Id = 1, Email = "pierre@citeo.com", CreationDate = DateTime.Now },
                new Customer() { Id = 2, Email = "paul@citeo.com", CreationDate = DateTime.Now },
                new Customer() { Id = 3, Email = "jaque@citeo.com", CreationDate = DateTime.Now }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order() { Id = 1, CustomerId = 1, CreationDate = DateTime.Now },
                new Order() { Id = 2, CustomerId = 2, CreationDate = DateTime.Now },
                new Order() { Id = 3, CustomerId = 3, CreationDate = DateTime.Now }

            );

            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem() { Id = 1, OrderId = 1, CreationDate = DateTime.Now, ProductId = 1, Quantity = 10 },
                new OrderItem() { Id = 2, OrderId = 2, CreationDate = DateTime.Now, ProductId = 2, Quantity = 1 },
                new OrderItem() { Id = 3, OrderId = 2, CreationDate = DateTime.Now, ProductId = 3, Quantity = 1 },
                new OrderItem() { Id = 4, OrderId = 3, CreationDate = DateTime.Now, ProductId = 4, Quantity = 1 }
            );

           


          


        }
         
    }
}
