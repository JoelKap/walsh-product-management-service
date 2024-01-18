using Walsh.Product.Management.Service.Bll.Contracts;
using Walsh.Product.Management.Service.Dal.Contracts;
using Walsh.Product.Management.Service.Model;

namespace Walsh.Product.Management.Service.Bll.Implimentations
{
    public class ProductService: IProductService
    {
        private readonly IProductDataAccess _productDataAccess;

        public ProductService(IProductDataAccess productDataAccess)
        {
            _productDataAccess = productDataAccess;
        }

        public Task<ProductModel> CreateProductAsync(ProductModel model) => _productDataAccess.CreateProductAsync(model);

        public Task DeleteProductAsync(int productId) => _productDataAccess.DeleteProductAsync(productId);

        public Task<ProductModel> GetProductAsync(int productId) => _productDataAccess.GetProductAsync(productId);

        public IEnumerable<ProductModel> GetProducts() => _productDataAccess.GetProducts();

        public Task<ProductModel> LikeOrUnlikeProductAsync(ProductModel model) => _productDataAccess.LikeOrUnlikeProductAsync(model);

        public IEnumerable<ProductModel> SearchProducts(string searchStr) => _productDataAccess.SearchProducts(searchStr);  

        public Task<ProductModel> UpdateProductAsync(ProductModel model) => _productDataAccess.UpdateProductAsync(model);   
    }
}
