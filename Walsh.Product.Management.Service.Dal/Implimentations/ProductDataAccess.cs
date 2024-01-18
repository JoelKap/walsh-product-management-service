using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Walsh.Product.Management.Service.Dal.Contracts;
using Walsh.Product.Management.Service.Dal.DTO;
using Walsh.Product.Management.Service.Model;

namespace Walsh.Product.Management.Service.Dal.Implimentations
{
    public class ProductDataAccess: IProductDataAccess
    {
        private readonly WalshDbContext _walshContext;
        private readonly IMapper _mapper;
        public ProductDataAccess(WalshDbContext walshContext)
        {
            _walshContext = walshContext;
            _mapper = Mappings.MappingProfile.MapperConfiguration();
        }

        public Task CreateProductAsync(ProductModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductModel> GetProduct(int productId)
        {
            var productDto = await _walshContext.Products.FirstOrDefaultAsync(product => product.ProductId == productId);

            if (productDto is null) return null;

            return _mapper.Map<DTO.Product, ProductModel>(productDto);
        }

        public IEnumerable<ProductModel> GetProducts()
        {
            var products = new List<ProductModel>();
            var productsDto = _walshContext.Products.Where(x => x.IsDeleted == false)
                                             .ToList();
            for (int i = 0; i < productsDto.Count; i++)
            {
                var product = _mapper.Map<Walsh.Product.Management.Service.Dal.DTO.Product, ProductModel>(productsDto[i]);
                products.Add(product);
            }
            return products;
        }

        public Task LikeOrUnlikeProductAsync(ProductModel model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductModel> SearchProducts(string searchStr)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductAsync(ProductModel model)
        {
            throw new NotImplementedException();
        }
    }
}
