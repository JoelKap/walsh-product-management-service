using Microsoft.AspNetCore.Mvc;
using Walsh.Product.Management.Service.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Walsh.Product.Management.Service.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // GET: api/<ProductController>
        [HttpGet]
        public List<ProductModel> Get()
        {
           return new List<ProductModel>();
        }

        // GET api/<ProductController>/5
        [HttpGet("{productId}")]
        public IActionResult GetProduct(int productId)
        {
            return Ok(new { productId });
        }

        // GET api/<ProductController>/str
        [HttpGet("searchProducts")]
        public IActionResult SearchProduct(string searchStr)
        {
            return null;
        }

        // POST api/<ProductController>
        [HttpPost()]
        public IActionResult Post(ProductModel model)
        {
            return Ok(true);
        }

        // PUT api/<ProductController>
        [HttpPut()]
        public IActionResult Put([FromBody] ProductModel model)
        {
            return Ok(true);
        }

        // PUT api/<ProductController>
        [HttpPut("LikeOrUnlikeProduct")]
        public IActionResult LikeorUnlikeProduct([FromBody] ProductModel model)
        {  
            return Ok(model);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{productId}")]
        public IActionResult Delete(int productId)
        {
            return NoContent();
        }
    }
}
