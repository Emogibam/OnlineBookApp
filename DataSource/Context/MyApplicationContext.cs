using DataSource.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataSource.Context
{
    public class MyApplicationContext  : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public MyApplicationContext(DbContextOptions<MyApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin<Guid>>().HasKey(l => new { l.LoginProvider, l.ProviderKey });

            modelBuilder.Entity<Book>(entity =>
            {
                // Other configurations
                entity.Property(b => b.Price).HasColumnType("decimal(18, 2)").IsRequired();
            });

            modelBuilder.Entity<Order>(entity =>
            {
                // Other configurations
                entity.Property(o => o.TotalPrice).HasColumnType("decimal(18, 2)").IsRequired();
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                // Other configurations
                entity.Property(od => od.UnitPrice).HasColumnType("decimal(18, 2)").IsRequired();
            });
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    // Additional entity configurations
        //    modelBuilder.Entity<ApplicationUser>(entity =>
        //    {
        //        entity.Property(u => u.FirstName).HasMaxLength(50).IsRequired();
        //        entity.Property(u => u.LastName).HasMaxLength(50).IsRequired();
        //        // Add other property configurations if needed
        //    });

        //    modelBuilder.Entity<Book>(entity =>
        //    {
        //        entity.Property(b => b.Title).HasMaxLength(100).IsRequired();
        //        entity.Property(b => b.AuthorId).IsRequired();
        //        entity.Property(b => b.GenreId).IsRequired();
        //        // Add other property configurations if needed

        //        // Relationship configuration
        //        entity.HasOne(b => b.Author)
        //              .WithMany(a => a.Books)
        //              .HasForeignKey(b => b.AuthorId)
        //              .OnDelete(DeleteBehavior.Restrict);

        //        entity.HasOne(b => b.Genre)
        //              .WithMany(g => g.Books)
        //              .HasForeignKey(b => b.GenreId)
        //              .OnDelete(DeleteBehavior.Restrict);
        //    });

        //    modelBuilder.Entity<Author>(entity =>
        //    {
        //        entity.Property(a => a.FirstName).HasMaxLength(50).IsRequired();
        //        entity.Property(a => a.LastName).HasMaxLength(50).IsRequired();
        //        // Add other property configurations if needed
        //    });

        //    modelBuilder.Entity<Genre>(entity =>
        //    {
        //        entity.Property(g => g.Name).HasMaxLength(50).IsRequired();
        //        // Add other property configurations if needed
        //    });

        //    modelBuilder.Entity<Order>(entity =>
        //    {
        //        entity.Property(o => o.OrderDate).IsRequired();
        //        entity.Property(o => o.TotalPrice).HasColumnType("decimal(18, 2)").IsRequired();
        //        entity.Property(o => o.OrderStatus).IsRequired();

        //        // Relationship configuration
        //        entity.HasOne(o => o.Customer)
        //              .WithMany(u => u.Orders)
        //              .HasForeignKey(o => o.CustomerId)
        //              .OnDelete(DeleteBehavior.Restrict);
        //    });

        //    modelBuilder.Entity<OrderDetail>(entity =>
        //    {
        //        entity.Property(od => od.Quantity).IsRequired();
        //        entity.Property(od => od.UnitPrice).HasColumnType("decimal(18, 2)").IsRequired();

        //        // Relationship configuration
        //        entity.HasOne(od => od.Order)
        //              .WithMany(o => o.OrderDetails)
        //              .HasForeignKey(od => od.OrderId)
        //              .OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletion of OrderDetail when an Order is deleted

        //        entity.HasOne(od => od.Book)
        //              .WithMany(b => b.OrderDetails)
        //              .HasForeignKey(od => od.BookId)
        //              .OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletion of OrderDetail when a Book is deleted
        //    });
        //}

    }
}
