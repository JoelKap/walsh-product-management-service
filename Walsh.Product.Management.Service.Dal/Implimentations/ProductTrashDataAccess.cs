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
            var productDto = _walshContext.Products.FirstOrDefault(product => product.ProductId == productId);
            if (productDto is null)
                throw new NotFoundException($"Product with ID {productId} not found");

            _walshContext.Products.Remove(productDto);
            await _walshContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductTrashModel>> GetProductTrashesAsync()
        {
            var productsDto = await _walshContext.Products
                .Where(product => product.IsDeleted == true)
                .ToListAsync();

            var products = _mapper.Map<List<DTO.Product>, List<ProductTrashModel>>(productsDto);

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
