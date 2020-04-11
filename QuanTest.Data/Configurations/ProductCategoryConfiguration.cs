using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanTest.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanTest.Data.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("ProductCategories");
            builder.HasKey(a => new { a.CategoryId, a.ProductId });
            builder.HasOne(a => a.Product).WithMany(a => a.ProductCategories).HasForeignKey(a => a.ProductId);
            builder.HasOne(a => a.Category).WithMany(a => a.ProductCategories).HasForeignKey(a => a.CategoryId);
        }
    }
}
