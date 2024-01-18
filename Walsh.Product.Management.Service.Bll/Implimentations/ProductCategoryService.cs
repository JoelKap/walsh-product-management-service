using Walsh.Product.Management.Service.Bll.Contracts;
using Walsh.Product.Management.Service.Dal.Contracts;
using Walsh.Product.Management.Service.Model;

namespace Walsh.Product.Management.Service.Bll.Implimentations
{
    public class ProductCategoryService: IProductCategoryService
    {
        private readonly IProductCategoryDataAccess _productCategoryDataAccess;

        public ProductCategoryService(IProductCategoryDataAccess productCategoryDataAccess)
        {
             _productCategoryDataAccess = productCategoryDataAccess;
        }

        public IEnumerable<ProductCategoryModel> GetCategories() => _productCategoryDataAccess.GetCategories();
    }
}
