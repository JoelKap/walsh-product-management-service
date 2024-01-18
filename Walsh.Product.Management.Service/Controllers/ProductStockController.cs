using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Walsh.Product.Management.Service.Bll.Contracts;
using Walsh.Product.Management.Service.Model;

namespace Walsh.Product.Management.Service.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductStockController : ControllerBase
    {
        private readonly IProductStockService _productStockService;

        public ProductStockController(IProductStockService productStockService)
        {
            _productStockService = productStockService;
        }

        // GET api/<ProductStockController>/5
        [HttpGet("{productId}")]
        public IActionResult GetProductStock(int productId)
        {
            return Ok(_productStockService.GetProductInStockAsync(productId));
        }

        // POST api/<ProductStockController>
        [HttpPost()]
        public IActionResult Post(ProductStockModel model)
        {
            if (model.Validate(out List<string> messages) == false)
            {
                return BadRequest(string.Join(Environment.NewLine, messages));
            }

            return Ok(_productStockService.CreateProductInStockAsync(model));
        }

        // PUT api/<ProductStockController>
        [HttpPut()]
        public IActionResult Put([FromBody] ProductStockModel model)
        {
            if (model.Validate(out List<string> messages) == false)
            {
                return BadRequest(string.Join(Environment.NewLine, messages));
            }

            return Ok(_productStockService.UpdateProductInStockAsync(model));
        }
    }
}
