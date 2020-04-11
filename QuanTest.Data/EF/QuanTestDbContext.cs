using Microsoft.EntityFrameworkCore;
using QuanTest.Data.Configurations;
using QuanTest.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanTest.Data.EF
{
    public class QuanTestDbContext : DbContext
    {
        public QuanTestDbContext( DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());
            //            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
