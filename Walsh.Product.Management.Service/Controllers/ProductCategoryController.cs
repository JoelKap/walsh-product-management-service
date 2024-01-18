using Microsoft.AspNetCore.Mvc;
using Walsh.Product.Management.Service.Bll.Contracts;
using Walsh.Product.Management.Service.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Walsh.Product.Management.Service.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_productCategoryService.GetCategories());
        }

    }
}
