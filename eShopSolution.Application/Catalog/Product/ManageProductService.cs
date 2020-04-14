using eShopSolution.Application.Common;
using eShopSolution.Data.EF;
using eShopSolution.Data.Entities;
using eShopSolution.Utilities.Exceptions;
using eShopSolution.ViewModels.Catalog.ProductImages;
using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Product
{
    public class ManageProductService : IManageProductService
    {
        private readonly EShopDbContext _context;
        private readonly IStorageService _storageService;
        public ManageProductService(eShopSolution.Data.EF.EShopDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<int> AddImage(int productId, ProductImageCreateRequest request)
        {
            var productImage = new ProductImage()
            {
                Caption = request.Caption,
                DateCreated = DateTime.Now,
                IsDefault = request.IsDefault,
                ProductId = productId,
                SortOrder = request.SortOrder
            };
            //Save Image
            if (request.ImageFile != null)
            {
                productImage.ImagePath = await this.SaveFile(request.ImageFile);
                productImage.FileSize = request.ImageFile.Length;                
            }

            _context.ProductImages.Add(productImage);
            return await _context.SaveChangesAsync();
        }

        public async Task AddViewCount(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            product.ViewCount += 1;
            await _context.SaveChangesAsync();
        }

        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new eShopSolution.Data.Entities.Product()
            {
                Price = request.Price,
                OriginalPrice = request.OriginalPrice,
                Stock = request.Stock,
                ViewCount = 0,

                DateCreated = DateTime.Now,
                ProductTranslations = new List<Data.Entities.ProductTranslation>() {
                    new Data.Entities.ProductTranslation()
                    {
                        Name = request.Name,
                        Description = request.Description,
                        SeoDescription = request.SeoDescription,
                        SeoAlias = request.SeoAlias,
                        LanguageId = request.LanguageId
                    }
                }
            };

            //Save Image
            if (request.ThumbnailImage != null)
            {
                product.ProductImages = new List<Data.Entities.ProductImage>()
                {
                    new Data.Entities.ProductImage()
                    {
                        Caption= request.Name,
                        DateCreated = DateTime.Now,
                        FileSize= request.ThumbnailImage.Length,
                        ImagePath= await this.SaveFile(request.ThumbnailImage),
                        IsDefault=true,
                        SortOrder=1
                    }
                };
            }
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }

        public async Task<int> Delete(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new EShopException($"Can not find a product: {productId}");

            var images = _context.ProductImages.Where(a => a.ProductId == productId);
            foreach (var image in images)
            {
                await _storageService.DeleteFileAsync(image.ImagePath);
            }
            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<PageResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request)
        {
            //1. Select
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pc in _context.ProductInCategories on p.Id equals pc.ProductId
                        join c in _context.Categories on pc.CategoryId equals c.Id
                        select new { p, pt, pc };
            //where pt.Name.Contains(request.Keyword);
            //2. Filter
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(p => p.pt.Name.Contains(request.Keyword));
            }
            if (request.CategoryIds.Count > 0)
            {
                query = query.Where(p => request.CategoryIds.Contains(p.pc.CategoryId));
            }

            //3. Paging
            int totalRow = await query.CountAsync();
            //Skip : bỏ qua số bản ghi đầu
            //Take : Lấy số bản ghi tiếp
            var data = await query.Skip((request.PageSize - 1) * request.PageSize).Take(request.PageSize)
                .Select(x => new ProductViewModel()
                {
                    Id = x.p.Id,
                    Name = x.pt.Name,
                    DateCreated = x.p.DateCreated,
                    Description = x.pt.Description,
                    Details = x.pt.Details,
                    LanguageId = x.pt.LanguageId,
                    Price = x.p.Price,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount
                }).ToListAsync();

            //4. Select and Projection
            var pateResult = new PageResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pateResult;
        }

        public async Task<ProductViewModel> GetById(int productId, string langueId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new EShopException($"Can not find a product: {productId}");

            var productTranslation = _context.ProductTranslations.FirstOrDefault(p => p.ProductId == productId && p.LanguageId == langueId);
            return new ProductViewModel()
            {
                Id = productId,
                DateCreated = product.DateCreated,
                Description = productTranslation == null ? "" : productTranslation.Description,
                Details = productTranslation == null ? "" : productTranslation.Details,
                LanguageId = langueId,
                Price = product.Price,
                SeoAlias = productTranslation == null ? "" : productTranslation.SeoAlias,
                SeoDescription = productTranslation == null ? "" : productTranslation.SeoDescription,
                SeoTitle = productTranslation == null ? "" : productTranslation.SeoTitle,
                Stock = product.Stock,
                ViewCount = product.ViewCount
            };
        }

        public async Task<List<ProductImageViewModel>> GetListImages(int productId)
        {
            var product = await _context.ProductImages.Where(a => a.ProductId == productId).Select(a => new ProductImageViewModel()
            {
                Caption = a.Caption,
                DateCreated = a.DateCreated,
                FileSize = a.FileSize,
                Id = a.Id,
                ImagePath = a.ImagePath,
                IsDefault = a.IsDefault,
                ProductId = a.ProductId,
                SortOrder = a.SortOrder
            }).ToListAsync();
            return product;
        }

        public async Task<int> RemoveImage(int productId, int productImageId)
        {
            var productImage = await _context.ProductImages.FindAsync(productImageId);
            if (productImage == null) throw new EShopException($"Not found image {productImageId}");
             _context.ProductImages.Remove(productImage);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> RemoveImages(int imageId)
        {
            var img = await _context.ProductImages.FirstOrDefaultAsync(a => a.Id == imageId);
            if (img == null)
                throw new EShopException($"Not found image {imageId}");
            _context.Remove(img);
            return await _context.SaveChangesAsync();

        }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _context.Products.FindAsync(request.Id);
            var productTranslation = await _context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == request.Id && x.LanguageId == request.LanguageId);
            if (product == null) throw new EShopException($"Can not find a product: { request.Id}");
            productTranslation.Name = request.Name;
            productTranslation.SeoAlias = request.SeoAlias;
            productTranslation.Name = request.Name;
            productTranslation.Description = request.Description;
            productTranslation.Details = request.Details;
            productTranslation.SeoTitle = request.SeoTitle;

            //Save Image
            if (request.ThumbnailImage != null)
            {
                var thumbnailImage = await _context.ProductImages.FirstOrDefaultAsync(a => a.IsDefault && a.ProductId == request.Id);
                if (thumbnailImage != null)
                {

                    thumbnailImage.FileSize = request.ThumbnailImage.Length;
                    thumbnailImage.ImagePath = await this.SaveFile(request.ThumbnailImage);
                    _context.ProductImages.Update(thumbnailImage);
                }
                product.ProductImages = new List<Data.Entities.ProductImage>()
                {
                    new Data.Entities.ProductImage()
                    {
                        Caption= request.Name,
                        DateCreated = DateTime.Now,
                        FileSize= request.ThumbnailImage.Length,
                        ImagePath= await this.SaveFile(request.ThumbnailImage),
                        IsDefault=true,
                        SortOrder=1
                    }
                };
            }

            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateImage(int productId, int productImageId, ProductImageUpdateRequest request)
        {
            var productImage = await _context.ProductImages.FindAsync(productImageId);
            if (productImage == null)
                throw new  EShopException($"not found image {productImageId}");
            
            //Save Image
            if (request.ImageFile != null)
            {
                productImage.ImagePath = await this.SaveFile(request.ImageFile);
                productImage.FileSize = request.ImageFile.Length;
            }
            _context.ProductImages.Update(productImage);
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePrice(int productId, decimal newPrice)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new EShopException($"Can not find a product: { productId}");
            product.Price = newPrice;
            return await _context.SaveChangesAsync() > 0;

        }

        public async Task<bool> UpdateStock(int productId, int addedQuantity)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new EShopException($"Can not find a product: { productId}");
            product.Stock = addedQuantity;
            return await _context.SaveChangesAsync() > 0;
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{ Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }
    }
}
