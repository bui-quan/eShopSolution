using eShopSolution.ViewModels.Common;
using System.Threading.Tasks;
using eShopSolution.ViewModels.Catalog.Products;

namespace eShopSolution.Application.Catalog.Product
{
    public interface IManageProductService
    {
        Task< int> Create(ProductCreateRequest request);
        Task<int> Update(ProductUpdateRequest request);

        Task<int> Delete(int productId);
        Task<bool> UpdatePrice(int productId, decimal newPrice);

        Task AddViewCount(int productId);
        Task<bool> UpdateStock(int productId, int addedQuantity);

        Task<PageResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request);
    }
}
