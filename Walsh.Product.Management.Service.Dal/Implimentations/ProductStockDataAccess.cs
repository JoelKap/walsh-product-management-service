using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Walsh.Product.Management.Service.Dal.Contracts;
using Walsh.Product.Management.Service.Dal.DTO;
using Walsh.Product.Management.Service.Model;
using Walsh.Product.Management.Service.Shared.CustomExceptions;

namespace Walsh.Product.Management.Service.Dal.Implimentations
{
    public class ProductStockDataAccess: IProductStockDataAccess
    {
        private readonly WalshDbContext _walshContext;
        private readonly IMapper _mapper;
        public ProductStockDataAccess(WalshDbContext walshContext)
        {
            _walshContext = walshContext;
            _mapper = Mappings.MappingProfile.MapperConfiguration();
        }

        public async Task<ProductStockModel> CreateProductInStockAsync(ProductStockModel model)
        {
            model.IsDeleted = false;
            model.CreatedAt = DateTime.Now;
            model.UpdateAt = DateTime.Now;

            var productDto = _mapper.Map<ProductStockModel, DTO.ProductStock>(model);

            _walshContext.ProductStocks.Add(productDto);

            try
            {
                await _walshContext.SaveChangesAsync();
                return model;
            }
            catch (DbUpdateException ex)
            {
                throw new UpdateFailedException("Failed to update product.", ex);
            }
        }

        public async Task<ProductStockModel> GetProductInStock(int productId)
        {
            var stockDto = await _walshContext.ProductStocks.FirstOrDefaultAsync(product => product.ProductId == productId);

            if (stockDto is null) return null;

            return _mapper.Map<DTO.ProductStock, ProductStockModel>(stockDto);
        }

        public async Task<ProductStockModel> UpdateProductInStockAsync(ProductStockModel model)
        {
            var stockDto = _walshContext.ProductStocks.FirstOrDefault(product => product.ProductId == model.ProductId);

            if (stockDto == null)
            {
                throw new NotFoundException($"Product with ID {model.ProductId} not found.");
            }

            _mapper.Map<ProductStockModel, ProductStock>(model, stockDto);

            try
            {
                await _walshContext.SaveChangesAsync();
                return model;
            }
            catch (Exception ex)
            {
                throw new UpdateFailedException("Failed to update product.", ex);
            }
        }
    }
}
