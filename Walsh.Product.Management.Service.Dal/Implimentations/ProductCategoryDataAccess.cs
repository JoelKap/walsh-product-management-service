using AutoMapper;
using Walsh.Product.Management.Service.Dal.Contracts;
using Walsh.Product.Management.Service.Dal.DTO;
using Walsh.Product.Management.Service.Model;

namespace Walsh.Product.Management.Service.Dal.Implimentations
{
    public class ProductCategoryDataAccess: IProductCategoryDataAccess
    {
        private readonly WalshDbContext _walshContext;
        private readonly IMapper _mapper;
        public ProductCategoryDataAccess(WalshDbContext walshContext)
        {
            _walshContext = walshContext;
            _mapper = Mappings.MappingProfile.MapperConfiguration();
        }

        public IEnumerable<ProductCategoryModel> GetCategories()
        {
            var categories = new List<ProductCategoryModel>();
            var categoriesDto = _walshContext.ProductCategories.ToList();

            for (int i = 0; i < categoriesDto.Count; i++)
            {
                var product = _mapper.Map<ProductCategory, ProductCategoryModel>(categoriesDto[i]);
                categories.Add(product);
            }
            return categories;
        }
    }
}
