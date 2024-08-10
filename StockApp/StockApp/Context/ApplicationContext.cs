using Microsoft.EntityFrameworkCore;
using StockApp.Entities;
using System;

namespace StockApp.Context
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Tables
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Product>().ToTable("Products");
            #endregion

            #region PrimaryKeys
            modelBuilder.Entity<User>().HasKey(s => s.Id);
            modelBuilder.Entity<Product>().HasKey(g => g.Id);
            #endregion

            
        }

    }
}
