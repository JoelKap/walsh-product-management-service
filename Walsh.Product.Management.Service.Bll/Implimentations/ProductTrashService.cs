using Walsh.Product.Management.Service.Bll.Contracts;
using Walsh.Product.Management.Service.Dal.Contracts;
using Walsh.Product.Management.Service.Model;

namespace Walsh.Product.Management.Service.Bll.Implimentations
{
    public class ProductTrashService: IProductTrashService
    {
        private readonly IProductTrashDataAccess _productTrashDataAccess;

        public ProductTrashService(IProductTrashDataAccess productTrashDataAccess)
        {
            _productTrashDataAccess = productTrashDataAccess;
        }

        public Task DeleteProductTrashAsync(int productId) => _productTrashDataAccess.DeleteProductTrashAsync(productId);

        public IEnumerable<ProductTrashModel> GetProductTrashes() => _productTrashDataAccess.GetProductTrashes();

        public Task<bool> RestoreProductTrashAsync(ProductTrashModel model) => _productTrashDataAccess.RestoreProductTrashAsync(model); 
    }
}
