using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Walsh.Product.Management.Service.Dal.Contracts;
using Walsh.Product.Management.Service.Dal.DTO;
using Walsh.Product.Management.Service.Model;

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

        public Task<ProductStockModel> CreateProductInStockAsync(ProductModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ProductStockModel> GetProductInStock(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<ProductStockModel> UpdateProductInStockAsync(ProductModel model)
        {
            throw new NotImplementedException();
        }
    }
}
