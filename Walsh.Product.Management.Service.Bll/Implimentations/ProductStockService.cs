using Walsh.Product.Management.Service.Bll.Contracts;
using Walsh.Product.Management.Service.Dal.Contracts;
using Walsh.Product.Management.Service.Model;

namespace Walsh.Product.Management.Service.Bll.Implimentations
{
    public class ProductStockService : IProductStockService
    {
        private readonly IProductStockDataAccess _productStockDataAccess;
        public ProductStockService(IProductStockDataAccess productStockDataAccess)
        {
            _productStockDataAccess = productStockDataAccess;
        }

        public Task<ProductStockModel> CreateProductInStockAsync(ProductStockModel model) => _productStockDataAccess.CreateProductInStockAsync(model);

        public Task<ProductStockModel> GetProductInStockAsync(int productId) => _productStockDataAccess.GetProductInStockAsync(productId);

        public Task<ProductStockModel> UpdateProductInStockAsync(ProductStockModel model) => _productStockDataAccess.UpdateProductInStockAsync(model);
    }
}
