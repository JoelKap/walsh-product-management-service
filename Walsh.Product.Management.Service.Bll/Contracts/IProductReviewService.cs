using Walsh.Product.Management.Service.Model;

namespace Walsh.Product.Management.Service.Bll.Contracts
{
    public interface IProductReviewService
    {
        Task<ProductReviewModel> GetProductReviewAsync(int productId);
        Task<ProductReviewModel> CreateProductReviewAsync(ProductReviewModel model);
        Task<ProductReviewModel> UpdateProductReviewAsync(ProductReviewModel model);
    }
}
