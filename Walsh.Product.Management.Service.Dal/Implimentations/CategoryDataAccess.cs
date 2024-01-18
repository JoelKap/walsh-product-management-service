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
    public class CategoryDataAccess: ICategoryDataAccess
    {
        private readonly WalshDbContext _walshContext;
        private readonly IMapper _mapper;
        public CategoryDataAccess(WalshDbContext walshContext)
        {
            _walshContext = walshContext;
            _mapper = Mappings.MappingProfile.MapperConfiguration();
        }

        public IEnumerable<ProductCategoryModel> GetLocations()
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
