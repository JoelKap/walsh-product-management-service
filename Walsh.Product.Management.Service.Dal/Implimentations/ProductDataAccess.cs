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
                return _mapper.Map<ProductModel>(productDto);
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
                .Include(product => product.Stock)
                .Include(product => product.ProductReviews.Where(review => review.ProductId == productId))
                .AsNoTracking()
                .Where(product => product.IsDeleted == false && product.ProductId == productId)
                .FirstOrDefaultAsync();

            if (productDto is null)
            {
                return null;
            }

            List<ProductReviewModel> productReviews = ConvertProductDtoToReviewModels(productId, productDto);
            ProductStockModel productStock = ConvertProductDtoToStockModel(productId, productDto);

            var productModel = _mapper.Map<ProductModel>(productDto);
            productModel.Reviews = productReviews;
            productModel.Stock = productStock;

            return productModel;
        }

        public IEnumerable<ProductModel> GetProducts()
        {
            var products = new List<ProductModel>();
            var productsDto = _walshContext.Products.Include(x => x.ProductReviews)
                                                    .Include(x => x.Stock)
                                                    .AsNoTracking()
                                                    .Where(x => x.IsDeleted == false)
                                                    .ToList();

            for (int i = 0; i < productsDto.Count; i++)
            {
                var product = _mapper.Map<DTO.Product, ProductModel>(productsDto[i]);
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
            var productDto = _walshContext.Products.FirstOrDefaultAsync(product => product.ProductId == model.ProductId).Result;

            if (productDto == null)
            {
                throw new NotFoundException($"Product with ID {model.ProductId} not found.");
            }

            var mappedProductDTO = _mapper.Map<ProductModel, DTO.Product>(model, productDto);
            _walshContext.Set<DTO.Product>().Update(productDto);

            try
            {
                _walshContext.SaveChanges();
                return _mapper.Map<ProductModel>(mappedProductDTO);
            }
            catch (Exception ex)
            {
                throw new UpdateFailedException("Failed to update product.", ex);
            }
        }


        private static List<ProductReviewModel>? ConvertProductDtoToReviewModels(int productId, DTO.Product? productDto)
        {
            return productDto.ProductReviews?.Select(review => new ProductReviewModel
            {
                CreatedAt = review.CreatedAt,
                IsDeleted = review.IsDeleted,
                ProductId = productId,
                ProductRating = review.ProductRating,
                ProductReviewDescription = review.ProductReviewDescription,
                ReviewId = review.ReviewId,
                UpdateAt = review.UpdateAt,
            }).ToList();
        }

        private static ProductStockModel ConvertProductDtoToStockModel(int productId, DTO.Product productDto)
        {
            return new ProductStockModel
            {
                StockId = productDto.Stock.StockId,
                IsDeleted = productDto.Stock.IsDeleted,
                CreatedAt = productDto.Stock.CreatedAt,
                ProductInStock = productDto.Stock.ProductInStock,
                UpdateAt = productDto.Stock.UpdateAt,
            };
        }
    }
}
