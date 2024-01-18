using Walsh.Product.Management.Service.Model;

namespace Walsh.Product.Management.Service.Dal.Contracts
{
    public interface ICategoryDataAccess
    {
        IEnumerable<ProductCategoryModel> GetLocations();
    }
}
