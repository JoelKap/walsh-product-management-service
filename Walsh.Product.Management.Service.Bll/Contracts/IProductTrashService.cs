using Walsh.Product.Management.Service.Model;

namespace Walsh.Product.Management.Service.Bll.Contracts
{
    public interface IProductTrashService
    {
        Task<IEnumerable<ProductTrashModel>> GetProductTrashesAsync();
        Task DeleteProductTrashAsync(int productId);
        Task<bool> RestoreProductTrashAsync(ProductTrashModel model);
    }
}
