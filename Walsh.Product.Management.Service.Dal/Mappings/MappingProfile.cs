using AutoMapper;
using Walsh.Product.Management.Service.Dal.DTO;
using Walsh.Product.Management.Service.Model;

namespace Walsh.Product.Management.Service.Dal.Mappings
{
    public class MappingProfile
    {
            public static IMapper MapperConfiguration()
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<List<Walsh.Product.Management.Service.Dal.DTO.Product>, List<ProductModel>>().ReverseMap();
                    cfg.CreateMap<Walsh.Product.Management.Service.Dal.DTO.Product, ProductModel>().ReverseMap();
                    cfg.CreateMap<ProductCategory, ProductCategoryModel>().ReverseMap();
                    cfg.CreateMap<ProductLocation, ProductLocationModel>().ReverseMap();
                    cfg.CreateMap<ProductReview, ProductReviewModel>().ReverseMap();
                    cfg.CreateMap<ProductStock, ProductStockModel>().ReverseMap();
                });

                IMapper mapper = config.CreateMapper();
                return mapper;
            }
    }
}
