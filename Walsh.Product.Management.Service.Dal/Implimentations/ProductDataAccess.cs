using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Walsh.Product.Management.Service.Dal.Contracts;
using Walsh.Product.Management.Service.Dal.DTO;
using Walsh.Product.Management.Service.Model;
using Walsh.Product.Management.Service.Shared.CustomExceptions;

namespace Walsh.Product.Management.Service.Dal.Implimentations
{
    public class ProductDataAccess : IProductDataAccess
    {
        private readonly WalshDbContext _walshContext;
        private readonly IMapper _mapper;
        public ProductDataAccess(WalshDbContext walshContext)
        {
            _walshContext = walshContext;
            _mapper = Mappings.MappingProfile.MapperConfiguration();
        }

        public async Task<ProductModel> CreateProductAsync(ProductModel model)
        {
            model.IsDeleted = false;
            model.CreatedAt = DateTime.Now;
            model.UpdateAt = DateTime.Now;

            var productDto = _mapper.Map<ProductModel, DTO.Product>(model);

            _walshContext.Products.Add(productDto);

            try
            {
                await _walshContext.SaveChangesAsync();

                model.ProductId = productDto.ProductId;
                return model;
            }
            catch (DbUpdateException ex)
            {
                throw new UpdateFailedException("Failed to update product.", ex);
            }
        }

        public async Task DeleteProductAsync(int productId)
        {
            var productDto = _walshContext.Products.FirstOrDefault(product => product.ProductId == productId);
            if (productDto is null)
                throw new NotFoundException($"Product with ID {productId} not found");

            productDto.IsDeleted = true;
            await _walshContext.SaveChangesAsync();
        }

        public async Task<ProductModel> GetProductAsync(int productId)
        {
            var productDto = await _walshContext.Products
                .Include(product => product.ProductStocks.Where(stock => stock.ProductId == productId))
                .Include(product => product.ProductReviews.Where(review => review.ProductId == productId))
                .AsNoTracking()
                .Where(product => product.IsDeleted == false && product.ProductId == productId)
                .FirstOrDefaultAsync();

            if (productDto is null)
            {
                return null;
            }

            List<ProductReviewModel>? productReviews = MapProductReview(productId, productDto);

            ProductStockModel? productStock = MapProductStock(productId, productDto);

            var productModel = _mapper.Map<ProductModel>(productDto);
            productModel.Reviews = productReviews;
            productModel.Stock = productStock;

            return productModel;
        }

        public IEnumerable<ProductModel> GetProducts()
        {
            var products = new List<ProductModel>();
            var productsDto = _walshContext.Products.Include(x => x.ProductReviews)
                                                    .AsNoTracking()
                                                    .Where(x => x.IsDeleted == false)
                                                    .ToList();

            for (int i = 0; i < productsDto.Count; i++)
            {
                var product = _mapper.Map<Walsh.Product.Management.Service.Dal.DTO.Product, ProductModel>(productsDto[i]);
                products.Add(product);
            }
            return products;
        }

        public async Task<ProductModel> LikeOrUnlikeProductAsync(ProductModel model)
        {
            return await UpdateProductAsync(model);
        }

        public IEnumerable<ProductModel> SearchProducts(string searchStr)
        {
            var products = new List<ProductModel>();
            var productsDto = _walshContext.Products
                .Where(product =>
                    (product.ProductTitle.Contains(searchStr) ||
                     product.ProductDescription.Contains(searchStr) ||
                     product.ProductPrice.ToString() == searchStr) &&
                    !product.IsDeleted)
                .ToList();

            for (int i = 0; i < productsDto.Count; i++)
            {
                var product = _mapper.Map<DTO.Product, ProductModel>(productsDto[i]);
                products.Add(product);
            }
            return products;
        }

        public async Task<ProductModel> UpdateProductAsync(ProductModel model)
        {
            var productDto = _walshContext.Products.FirstOrDefault(product => product.ProductId == model.ProductId);

            if (productDto == null)
            {
                throw new NotFoundException($"Product with ID {model.ProductId} not found.");
            }

            _mapper.Map<ProductModel, DTO.Product>(model, productDto);
            var entity = _walshContext.Set<DTO.Product>().Update(productDto);

            try
            {
                 _walshContext.SaveChanges();
                return model;
            }
            catch (Exception ex)
            {
                throw new UpdateFailedException("Failed to update product.", ex);
            }
        }


        private static List<ProductReviewModel>? MapProductReview(int productId, DTO.Product? productDto)
        {
            return productDto.ProductReviews?.Select(review => new ProductReviewModel
            {
                CreatedAt = review.CreatedAt,
                IsDeleted = review.IsDeleted,
                ProductId = productId,
                ProductRating = review.ProductRating,
                ProductReview = review.ProductReview1,
                ReviewId = review.ReviewId,
                UpdateAt = review.UpdateAt,
            }).ToList();
        }

        private static ProductStockModel? MapProductStock(int productId, DTO.Product? productDto)
        {
            return productDto.ProductStocks?.Select(stock => new ProductStockModel
            {
                CreatedAt = stock.CreatedAt,
                IsDeleted = stock.IsDeleted,
                ProductId = productId,
                ProductInStock = stock.ProductInStock,
                UpdateAt = stock.UpdateAt,
                StockId = stock.StockId
            }).FirstOrDefault();
        }
    }
}
