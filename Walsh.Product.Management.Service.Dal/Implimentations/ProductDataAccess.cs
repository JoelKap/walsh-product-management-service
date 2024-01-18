using Walsh.Product.Management.Service.Dal.Contracts;
using Walsh.Product.Management.Service.Model;

namespace Walsh.Product.Management.Service.Dal.Implimentations
{
    public class ProductDataAccess: IProductDataAccess
    {
        public ProductDataAccess()
        {
            
        }

        public Task CreateProductAsync(ProductModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<ProductModel> GetProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductModel> GetProducts()
        {
            throw new NotImplementedException();
        }

        public Task LikeOrUnlikeProductAsync(ProductModel model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductModel> SearchProducts(string searchStr)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductAsync(ProductModel model)
        {
            throw new NotImplementedException();
        }
    }
}
