using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Walsh.Product.Management.Service.Dal.Contracts;
using Walsh.Product.Management.Service.Dal.DTO;
using Walsh.Product.Management.Service.Model;
using Walsh.Product.Management.Service.Shared.CustomExceptions;

namespace Walsh.Product.Management.Service.Dal.Implimentations
{
    public class ProductTrashDataAccess : IProductTrashDataAccess
    {
        private readonly WalshDbContext _walshContext;
        private readonly IProductDataAccess _productDataAccess;
        private readonly IMapper _mapper;
        public ProductTrashDataAccess(WalshDbContext walshContext, IProductDataAccess productDataAccess)
        {
            _walshContext = walshContext;
            _mapper = Mappings.MappingProfile.MapperConfiguration();
            _productDataAccess = productDataAccess;
        }

        public async Task DeleteProductTrashAsync(int productId)
        {
            var productDto = _walshContext.Products
                               .Include(p => p.ProductReviews)
                               .Include(p => p.Stock)
                               .FirstOrDefault(product => product.ProductId == productId);

            if (productDto is null)
                throw new NotFoundException($"Product with ID {productId} not found");

            if (productDto.ProductReviews != null && productDto.ProductReviews.Any())
                _walshContext.ProductReviews.RemoveRange(productDto.ProductReviews);
            
            _walshContext.Products.Remove(productDto);

            if (productDto.Stock != null)
                _walshContext.ProductStocks.Remove(productDto.Stock);

            await _walshContext.SaveChangesAsync();
        }

        public IEnumerable<ProductTrashModel> GetProductTrashes()
        {
            var products = new List<ProductTrashModel>();
            var productsDto = _walshContext.Products
                                        .Include(x => x.ProductReviews)
                                        .Include(x => x.Stock)
                                        .AsNoTracking()
                                        .Where(x => x.IsDeleted == true)
                                        .ToList();

            for (int i = 0; i < productsDto.Count; i++)
            {
                var product = _mapper.Map<DTO.Product, ProductTrashModel>(productsDto[i]);
                products.Add(product);
            }

            return products;
        }


        public async Task<bool> RestoreProductTrashAsync(ProductTrashModel model)
        {
            try
            {
                ProductModel productModel = model as ProductModel;
                if (productModel != null)
                {
                    productModel.IsDeleted = false;
                    await _productDataAccess.UpdateProductAsync(productModel);
                    return true;
                }
                throw new ArgumentNullException(nameof(model), "ProductTrashModel cannot be null.");
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Invalid operation during product restoration.");
            }
        }
    }
}
