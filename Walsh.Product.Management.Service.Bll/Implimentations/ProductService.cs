using Walsh.Product.Management.Service.Bll.Contracts;
using Walsh.Product.Management.Service.Dal.Contracts;
using Walsh.Product.Management.Service.Dal.Implimentations;
using Walsh.Product.Management.Service.Model;

namespace Walsh.Product.Management.Service.Bll.Implimentations
{
    public class ProductService : IProductService
    {
        private readonly IProductDataAccess _productDataAccess;
        private readonly IProductReviewDataAccess _productReviewDataAccess;
        private readonly IProductStockDataAccess _productStockDataAccess;

        public ProductService(IProductDataAccess productDataAccess,
                            IProductReviewDataAccess productReviewDataAccess,
                            IProductStockDataAccess productStockDataAccess
                            )
        {
            _productDataAccess = productDataAccess;
            _productReviewDataAccess = productReviewDataAccess;
            _productStockDataAccess = productStockDataAccess;
        }

        public async Task<ProductModel> CreateProductAsync(ProductModel model)
        {
            var product = await _productDataAccess.CreateProductAsync(model);

            var productStockModel = new ProductStockModel();
            productStockModel.ProductId = model.ProductId;
            productStockModel.ProductInStock = model.Stock.ProductInStock;
            var createdProductInStock = await _productStockDataAccess.CreateProductInStockAsync(productStockModel);

            var productReviewModel = new ProductReviewModel();
            productReviewModel.ProductId = model.ProductId;
            productReviewModel.ProductReview = model.Reviews.FirstOrDefault().ProductReview;
            productReviewModel.ProductRating = model.Reviews.FirstOrDefault().ProductRating;

            var createdProductReview = await _productReviewDataAccess.CreateProductReviewAsync(productReviewModel);

            product.Reviews = new List<ProductReviewModel> { createdProductReview }; ;
            product.Stock = createdProductInStock;

            return product;
        }

        public Task DeleteProductAsync(int productId) => _productDataAccess.DeleteProductAsync(productId);

        public Task<ProductModel> GetProductAsync(int productId) => _productDataAccess.GetProductAsync(productId);

        public IEnumerable<ProductModel> GetProducts() => _productDataAccess.GetProducts();

        public Task<ProductModel> LikeOrUnlikeProductAsync(ProductModel model) => _productDataAccess.LikeOrUnlikeProductAsync(model);

        public IEnumerable<ProductModel> SearchProducts(string searchStr) => _productDataAccess.SearchProducts(searchStr);

        public async Task<ProductModel> UpdateProductAsync(ProductModel model)
        {
            return await _productDataAccess.UpdateProductAsync(model);
        }
    }
}
