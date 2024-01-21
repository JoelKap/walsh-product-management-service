using Walsh.Product.Management.Service.Model;

namespace Walsh.Product.Management.Service.Dal.Contracts
{
    public interface IProductTrashDataAccess
    {
        IEnumerable<ProductTrashModel> GetProductTrashes();
        Task DeleteProductTrashAsync(int productId);
        Task<bool> RestoreProductTrashAsync(ProductTrashModel model);
    }
}
