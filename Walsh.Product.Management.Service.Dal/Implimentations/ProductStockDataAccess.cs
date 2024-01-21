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

            var productStockDto = _mapper.Map<ProductStockModel, DTO.ProductStock>(model);

            _walshContext.ProductStocks.Add(productStockDto);

            try
            {
                await _walshContext.SaveChangesAsync();
                var productStockModel = _mapper.Map<ProductStockModel>(productStockDto);
                return productStockModel;
            }
            catch (DbUpdateException ex)
            {
                throw new UpdateFailedException("Failed to update stock.", ex);
            }
        }

        public async Task<ProductStockModel> GetProductInStockAsync(int stockId)
        {
            var stockDto = await _walshContext.ProductStocks.FirstOrDefaultAsync(stock => stock.StockId == stockId);

            if (stockDto is null) return null;

            return _mapper.Map<DTO.ProductStock, ProductStockModel>(stockDto);
        }

        public async Task<ProductStockModel> UpdateProductInStockAsync(ProductStockModel model)
        {
            var stockDto = _walshContext.ProductStocks.FirstOrDefault(product => product.StockId == model.StockId);

            if (stockDto == null)
            {
                throw new NotFoundException($"Product with ID {model.StockId} not found.");
            }

            _mapper.Map<ProductStockModel, ProductStock>(model, stockDto);

            try
            {
                await _walshContext.SaveChangesAsync();
                return model;
            }
            catch (Exception ex)
            {
                throw new UpdateFailedException("Failed to update stock.", ex);
            }
        }
    }
}
