using Walsh.Product.Management.Service.Bll.Contracts;
using Walsh.Product.Management.Service.Dal.Contracts;
using Walsh.Product.Management.Service.Model;

namespace Walsh.Product.Management.Service.Bll.Implimentations
{
    public class ProductLocationService: IProductLocationService
    {
        private readonly IProductLocationDataAccess _productLocationDataAccess;
        public ProductLocationService(IProductLocationDataAccess productLocationDataAccess)
        {
            _productLocationDataAccess = productLocationDataAccess;
        }

        public IEnumerable<ProductLocationModel> GetLocations() => _productLocationDataAccess.GetLocations();
    }
}
