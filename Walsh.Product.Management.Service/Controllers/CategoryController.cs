using Microsoft.AspNetCore.Mvc;
using Walsh.Product.Management.Service.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Walsh.Product.Management.Service.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        // GET: api/<CategoryController>
        [HttpGet]
        public List<ProductCategoryModel> Get()
        {
            var dummyCategories = new List<ProductCategoryModel>() {
                new ProductCategoryModel(){
                        CategoryId = 1,
                        CategoryName = "Books"
                        },
                        new ProductCategoryModel(){
                        CategoryId = 2,
                        CategoryName = "Movies"
                        },
                        new ProductCategoryModel(){
                        CategoryId = 3,
                        CategoryName = "Games"
                   }
            };
            return dummyCategories;
        }

    }
}
