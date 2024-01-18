using Walsh.Product.Management.Service.Model;

namespace Walsh.Product.Management.Service.Bll.Contracts
{
    public interface IProductStockService
    {
        Task<ProductStockModel> GetProductInStockAsync(int productId);
        Task<ProductStockModel> CreateProductInStockAsync(ProductStockModel model);
        Task<ProductStockModel> UpdateProductInStockAsync(ProductStockModel model);
    }
}
