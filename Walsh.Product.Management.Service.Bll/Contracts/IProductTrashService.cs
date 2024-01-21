using Walsh.Product.Management.Service.Model;

namespace Walsh.Product.Management.Service.Bll.Contracts
{
    public interface IProductTrashService
    {
        IEnumerable<ProductTrashModel> GetProductTrashes();
        Task DeleteProductTrashAsync(int productId);
        Task<bool> RestoreProductTrashAsync(ProductTrashModel model);
    }
}
