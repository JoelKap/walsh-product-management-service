using Walsh.Product.Management.Service.Model;

namespace Walsh.Product.Management.Service.Dal.Contracts
{
    public interface IProductStockDataAccess
    { 
        Task<ProductStockModel> GetProductInStockAsync(int productId);
        Task<ProductStockModel> CreateProductInStockAsync(ProductStockModel model);
        Task<ProductStockModel> UpdateProductInStockAsync(ProductStockModel model);
    }
}
