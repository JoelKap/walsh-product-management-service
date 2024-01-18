using Walsh.Product.Management.Service.Bll.Contracts;
using Walsh.Product.Management.Service.Dal.Contracts;
using Walsh.Product.Management.Service.Model;

namespace Walsh.Product.Management.Service.Bll.Implimentations
{
    public class ProductReviewService: IProductReviewService
    {
        private readonly IProductReviewDataAccess _productReviewDataAccess;
        public ProductReviewService(IProductReviewDataAccess productReviewDataAccess)
        {
            _productReviewDataAccess = productReviewDataAccess;
        }

        public Task<ProductReviewModel> CreateProductReviewAsync(ProductReviewModel model) => _productReviewDataAccess.CreateProductReviewAsync(model); 

        public Task<ProductReviewModel> GetProductReviewAsync(int productId) => _productReviewDataAccess.GetProductReviewAsync(productId);

        public Task<ProductReviewModel> UpdateProductReviewAsync(ProductReviewModel model) => _productReviewDataAccess.UpdateProductReviewAsync(model);
    }
}
