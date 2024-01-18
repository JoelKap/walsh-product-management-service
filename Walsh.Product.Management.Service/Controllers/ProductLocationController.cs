using Microsoft.AspNetCore.Mvc;
using Walsh.Product.Management.Service.Bll.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Walsh.Product.Management.Service.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductLocationController : ControllerBase
    {
        private readonly IProductLocationService _productLocationService;

        public ProductLocationController(IProductLocationService productLocationService)
        {
            _productLocationService = productLocationService;
        }
        
        // GET: api/<ProductLocationController>
        [HttpGet]
        public IActionResult Get() 
        {
            return Ok(_productLocationService.GetLocations());
        }
    }
}
