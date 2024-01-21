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
                cfg.CreateMap<DTO.Product, ProductModel>()
                    .ForMember(dest => dest.Reviews, src => src.MapFrom(o => o.ProductReviews))
                    .ForMember(dest => dest.Stock, src => src.MapFrom(o => o.Stock));

                cfg.CreateMap<DTO.Product, ProductTrashModel>()
                    .ForMember(dest => dest.Reviews, src => src.MapFrom(o => o.ProductReviews))
                    .ForMember(dest => dest.Stock, src => src.MapFrom(o => o.Stock));

                cfg.CreateMap<ProductModel, DTO.Product>()
                    .ForMember(dest => dest.ProductReviews, src => src.MapFrom(o => o.Reviews))
                    .ForMember(dest => dest.Stock, src => src.MapFrom(o => o.Stock));
               
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
