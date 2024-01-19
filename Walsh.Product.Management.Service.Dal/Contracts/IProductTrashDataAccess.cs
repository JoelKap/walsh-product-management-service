using Walsh.Product.Management.Service.Model;

namespace Walsh.Product.Management.Service.Dal.Contracts
{
    public interface IProductTrashDataAccess
    {
        Task<IEnumerable<ProductTrashModel>> GetProductTrashesAsync();
        Task DeleteProductTrashAsync(int productId);
        Task<bool> RestoreProductTrashAsync(ProductTrashModel model);
    }
}
