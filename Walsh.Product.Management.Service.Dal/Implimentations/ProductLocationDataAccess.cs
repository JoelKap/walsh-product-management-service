using AutoMapper;
using Walsh.Product.Management.Service.Dal.Contracts;
using Walsh.Product.Management.Service.Dal.DTO;
using Walsh.Product.Management.Service.Model;

namespace Walsh.Product.Management.Service.Dal.Implimentations
{
    public class ProductLocationDataAccess: IProductLocationDataAccess
    {
        private readonly WalshDbContext _walshContext;
        private readonly IMapper _mapper;
        public ProductLocationDataAccess(WalshDbContext walshContext)
        {
            _walshContext = walshContext;
            _mapper = Mappings.MappingProfile.MapperConfiguration();
        }

        public IEnumerable<ProductLocationModel> GetLocations()
        {
            var locations = new List<ProductLocationModel>();
            var locationsDto = _walshContext.ProductLocations.ToList();

            for (int i = 0; i < locationsDto.Count; i++)
            {
                var location = _mapper.Map<ProductLocation, ProductLocationModel>(locationsDto[i]);
                locations.Add(location);
            }
            return locations;
        }
    }
}
