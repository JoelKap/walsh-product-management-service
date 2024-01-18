using Walsh.Product.Management.Service.Model;

namespace Walsh.Product.Management.Service.Dal.Contracts
{
    public interface IProductStockDataAccess
    { 
        Task<ProductStockModel> GetProductInStock(int productId);
        Task<ProductStockModel> CreateProductInStockAsync(ProductModel model);
        Task<ProductStockModel> UpdateProductInStockAsync(ProductModel model);
    }
}
