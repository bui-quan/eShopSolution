using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
    class ProductInCategoryConfiguration : IEntityTypeConfiguration<ProductInCategory>
    {
        public void Configure(EntityTypeBuilder<ProductInCategory> builder)
        {
            builder.ToTable("ProductInCategories");
            //builder.HasKey(x => x.ProductId & x.CategoryId);
            builder.HasKey(x => new  { x.ProductId , x.CategoryId });
            builder.HasOne(x => x.Product).WithMany(p => p.ProductsInCategories).HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.Category).WithMany(p => p.ProductInCategories).HasForeignKey(x => x.CategoryId);

        }
    }
}
