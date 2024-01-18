using Microsoft.AspNetCore.Mvc;
using Walsh.Product.Management.Service.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Walsh.Product.Management.Service.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrashController : ControllerBase
    {
        // GET: api/<TrashController>
        [HttpGet]
        public List<ProductModel> Get()
        {
            return new List<ProductModel>();
        }

        // GET api/<TrashController>/5
        [HttpPut("RestoreProduct")]
        public IActionResult Restore([FromBody] ProductModel model)
        {
            return Ok(true); 
        }

        // DELETE api/<TrashController>/5
        [HttpDelete("{productId}")]
        public IActionResult Delete(int productId)
        {
            return NoContent();
        }
    }
}
