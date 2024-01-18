using Walsh.Product.Management.Service.Model;

namespace Walsh.Product.Management.Service.Dal.Contracts
{
    public interface IProductDataAccess
    {
        IEnumerable<ProductModel> GetProducts(); 
        Task<ProductModel> GetProductAsync(int productId);
        IEnumerable<ProductModel> SearchProducts(string searchStr);
        Task<ProductModel> CreateProductAsync(ProductModel model);
        Task<ProductModel> UpdateProductAsync(ProductModel model);
        Task<ProductModel> LikeOrUnlikeProductAsync(ProductModel model);
        Task DeleteProductAsync(int productId);
    } 
}
