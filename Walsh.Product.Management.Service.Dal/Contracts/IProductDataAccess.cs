using Walsh.Product.Management.Service.Model;

namespace Walsh.Product.Management.Service.Dal.Contracts
{
    public interface IProductDataAccess
    {
        IEnumerable<ProductModel> GetProducts(); 
        Task<ProductModel> GetProduct(int productId);
        IEnumerable<ProductModel> SearchProducts(string searchStr);
        Task CreateProductAsync(ProductModel model); 
        Task UpdateProductAsync(ProductModel model); 
        Task LikeOrUnlikeProductAsync(ProductModel model);
        Task DeleteProductAsync(int productId);
    } 
}
