using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(

                    new AppConfig() { Key = "HomeTitle", Value = "This is home page of eShopSolution" },
                    new AppConfig() { Key = "HomeKeyword", Value = "This is keyword of eShopSolution" },
                    new AppConfig() { Key = "HomeDescription", Value = "This description of eShopSolution" }
                );
            modelBuilder.Entity<Language>().HasData(

                    new Language() { Id = "vi-VN", Name = "Tiếng Việt", IsDefault = true },
                    new Language() { Id = "en-US", Name = "English", IsDefault = false }

                );
            modelBuilder.Entity<Category>().HasData(

                    new Category() { Id = 1, IsShowOnHome = true, ParentId = null, SortOrder = 1, Status = Enums.Status.Active },

                    new Category()
                    {
                        Id = 2,
                        IsShowOnHome = true,
                        ParentId = null,
                        SortOrder = 1,
                        Status = Enums.Status.Active

                    }

                );
            modelBuilder.Entity<CategoryTranslation>().HasData(
                    new CategoryTranslation() {Id=1,CategoryId=1, LanguageId = "vi-VN", Name = "Áo nam", SeoAlias = "ao-nam", SeoDescription = "Sản phẩm thời trang nam", SeoTitle = "Sản phẩm thời trang nam" },
                    new CategoryTranslation() {Id=2,CategoryId=1, LanguageId = "en-US", Name = "Men shirt", SeoAlias = "men-shirt", SeoDescription = "The shirt product for men", SeoTitle = "The shirt product for men" },
                    new CategoryTranslation() {Id=3,CategoryId=2, LanguageId = "vi-VN", Name = "Áo nữ", SeoAlias = "ao-nu", SeoDescription = "Sản phẩm thời trang nữ", SeoTitle = "Sản phẩm thời trang nữ" },
                    new CategoryTranslation() {Id=4,CategoryId=2, LanguageId = "en-US", Name = "Women shirt", SeoAlias = "women-shirt", SeoDescription = "The shirt product for women", SeoTitle = "The shirt product for women" }

                );
            modelBuilder.Entity<Product>().HasData(

                    new Product()
                    {
                        Id = 1,
                        DateCreated = DateTime.Now,
                        OriginalPrice = 100,
                        Price = 200,
                        Stock = 0,
                        ViewCount = 0,

                    },
                    new Product()
                    {
                        Id = 2,
                        DateCreated = DateTime.Now,
                        OriginalPrice = 100,
                        Price = 200,
                        Stock = 0,
                        ViewCount = 0,


                    }
                );

            modelBuilder.Entity<ProductTranslation>().HasData(
                    new ProductTranslation() {Id=1, ProductId = 1, LanguageId = "vi-VN", Name = "Áo nam", SeoAlias = "ao-nam", SeoDescription = "Sản phẩm thời trang nam", SeoTitle = "Sản phẩm thời trang nam", Details = "Mô tả sản phẩm", Description = "" },
                    new ProductTranslation() {Id=2, ProductId = 1, LanguageId = "en-US", Name = "Men shirt", SeoAlias = "men-shirt", SeoDescription = "The shirt product for men", SeoTitle = "The shirt product for men", Details = "Description of product", Description = "" },
                    new ProductTranslation() {Id=3, ProductId = 2, LanguageId = "vi-VN", Name = "Áo nam Viet tien", SeoAlias = "ao-nam-viet tien", SeoDescription = "Sản phẩm thời trang nam viet tien", SeoTitle = "Sản phẩm thời trang nam", Details = "Mô tả sản phẩm", Description = "" },
                    new ProductTranslation() {Id=4, ProductId = 2, LanguageId = "en-US", Name = "Men shirt Viet tien", SeoAlias = "men-shirt Viet tien", SeoDescription = "The shirt product for men Viet tien", SeoTitle = "The shirt product for men Viet tien", Details = "Description of product Viet tien", Description = " Viet tien" }
                );

            modelBuilder.Entity<ProductInCategory>().HasData(

                    new ProductInCategory() { ProductId = 1, CategoryId = 1 },
                    new ProductInCategory() { ProductId = 2, CategoryId = 2 }

                );
        }
    }
}
