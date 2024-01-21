using Microsoft.AspNetCore.Mvc;
using Walsh.Product.Management.Service.Bll.Contracts;
using Walsh.Product.Management.Service.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Walsh.Product.Management.Service.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrashController : ControllerBase
    {
        private readonly IProductTrashService _productTrashService;

        public TrashController(IProductTrashService productTrashService)
        {
            _productTrashService = productTrashService;
        }

        // GET: api/<TrashController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_productTrashService.GetProductTrashes());
        }

        // GET api/<TrashController>/5
        [HttpPut("RestoreProduct")]
        public IActionResult Restore([FromBody] ProductTrashModel model)
        {
            return Ok(_productTrashService.RestoreProductTrashAsync(model).Result);
        }

        // DELETE api/<TrashController>/5
        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete(int productId)
        {
            await _productTrashService.DeleteProductTrashAsync(productId);
            return NoContent();
        }
    }
}
