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
        public async Task<IActionResult> GetProductStock(int productId)
        {
            var productStocks = await _productStockService.GetProductInStockAsync(productId);

            return Ok(productStocks);
        }
    }
}
