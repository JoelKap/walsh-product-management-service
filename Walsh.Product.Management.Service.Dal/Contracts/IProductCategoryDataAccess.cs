using Walsh.Product.Management.Service.Model;

namespace Walsh.Product.Management.Service.Dal.Contracts
{
    public interface IProductCategoryDataAccess
    {
        IEnumerable<ProductCategoryModel> GetCategories();
    }
}
