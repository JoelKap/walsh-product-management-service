using Walsh.Product.Management.Service.Model;

namespace Walsh.Product.Management.Service.Dal.Contracts
{
    public interface IProductReviewDataAccess 
    {  
        Task<ProductReviewModel> GetProductReviewAsync(int productId);
        Task<ProductReviewModel> CreateProductReviewAsync(ProductReviewModel model);
        Task<ProductReviewModel> UpdateProductReviewAsync(ProductReviewModel model);
    }
}
