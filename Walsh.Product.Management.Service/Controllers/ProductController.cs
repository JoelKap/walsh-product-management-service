using Microsoft.AspNetCore.Mvc;
using Walsh.Product.Management.Service.Bll.Contracts;
using Walsh.Product.Management.Service.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Walsh.Product.Management.Service.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_productService.GetProducts());
        }

        // GET api/<ProductController>/5
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProduct(int productId)
        {
            return Ok(await _productService.GetProductAsync(productId));
        }

        // GET api/<ProductController>/str
        [HttpGet("searchProducts")]
        public IActionResult SearchProduct(string searchStr)
        {
            return Ok(_productService.SearchProducts(searchStr));
        }

        // POST api/<ProductController>
        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] ProductModel model)
        {
            if (model.Validate(out List<string> messages) == false)
            {
                return BadRequest(string.Join(Environment.NewLine, messages));
            }

            return Ok(await _productService.CreateProductAsync(model));
        }

        // PUT api/<ProductController>
        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] ProductModel model)
        {
            if (model.Validate(out List<string> messages) == false)
            {
                return BadRequest(string.Join(Environment.NewLine, messages));
            }

            return Ok(await _productService.UpdateProductAsync(model));
        }

        // PUT api/<ProductController>
        [HttpPut("LikeOrUnlikeProduct")]
        public IActionResult LikeOrUnlikeProduct([FromBody] ProductModel model)
        {
            if (model.Validate(out List<string> messages) == false)
            {
                return BadRequest(string.Join(Environment.NewLine, messages));
            }

            return Ok(_productService.LikeOrUnlikeProductAsync(model));
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete(int productId)
        {
            await _productService.DeleteProductAsync(productId);
            return NoContent();
        }
    }
}
