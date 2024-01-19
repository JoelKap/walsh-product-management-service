using Microsoft.AspNetCore.Mvc;
using Walsh.Product.Management.Service.Bll.Contracts;
using Walsh.Product.Management.Service.Model;

namespace Walsh.Product.Management.Service.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductReviewController : ControllerBase
    {
        private readonly IProductReviewService _productReviewService;

        public ProductReviewController(IProductReviewService productReviewService)
        {
            _productReviewService = productReviewService;
        }

        // GET api/<ProductReviewController>/5
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductReview(int productId)
        {
            var productReview = await _productReviewService.GetProductReviewAsync(productId);
            return Ok(productReview);
        }
    }
}
