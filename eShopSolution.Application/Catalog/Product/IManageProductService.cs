using eShopSolution.ViewModels.Common;
using System.Threading.Tasks;
using eShopSolution.ViewModels.Catalog.Products;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using eShopSolution.ViewModels.Catalog.ProductImages;

namespace eShopSolution.Application.Catalog.Product
{
    public interface IManageProductService
    {
        Task< int> Create(ProductCreateRequest request);
        Task<int> Update(ProductUpdateRequest request);
        Task<int> Delete(int productId);
        Task<bool> UpdatePrice(int productId, decimal newPrice);
        Task<ProductViewModel> GetById(int id, string langueId);
        Task AddViewCount(int productId);
        Task<bool> UpdateStock(int productId, int addedQuantity);
        Task<PageResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request);
        Task<int> AddImage(int productId, ProductImageCreateRequest productImageCreateRequest);
        Task<int> RemoveImage(int productId, int productImageId);
        Task<int> UpdateImage(int productId, int productImageId,ProductImageUpdateRequest productImageUpdateRequest);
        Task<List<ProductImageViewModel>> GetListImages(int productId);
    }
}
