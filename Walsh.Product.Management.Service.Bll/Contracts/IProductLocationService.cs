using Walsh.Product.Management.Service.Model;

namespace Walsh.Product.Management.Service.Bll.Contracts
{
    public interface IProductLocationService
    {
        IEnumerable<ProductLocationModel> GetLocations();
    }
}
