using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.ToTable("ProductImages");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(a => a.ImagePath).HasMaxLength(200).IsRequired();
            builder.Property(a => a.ImagePath).HasMaxLength(200);

            builder.HasOne(a => a.Product).WithMany(a => a.ProductImages).HasForeignKey(a => a.ProductId);
        }
    }
}
