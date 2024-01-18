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
            var dummyProducts = new List<ProductModel>
            {
                new ProductModel
                {
                    ProductId = 1,
                    CategoryId = 2,
                    ProductTitle = "Product 1",
                    ProductImageUrl = "https://picsum.photos/100/50",
                    ProductDescription = "Introducing the revolutionary QuantumBlaze X3, a cutting-edge device that seamlessly combines style and functionality for the ultimate user experience. This sleek gadget is designed to elevate your daily routine, offering a myriad of features that cater to your every need.",
                    ProductLike = true,
                    ProductReview = "Good product",
                    ProductRating = 5,
                    LocationId = 1,
                    ProductPrice = 100,
                    ProductInStock = "IN",
                },
                new ProductModel
                {
                    ProductId = 2,
                    CategoryId = 1,
                    ProductTitle = "Product 2",
                    ProductImageUrl = "https://picsum.photos/100/50",
                    ProductDescription = "The QuantumBlaze X3 boasts a stunning 6.4-inch Infinity Display, providing crystal-clear visuals and immersive colors for an unparalleled viewing experience. Powered by the latest Octa-Core processor, this device ensures lightning-fast performance, allowing you to multitask effortlessly and run demanding applications with ease.",
                    ProductLike = false,
                    ProductReview = "Average product",
                    ProductRating = 3,
                    LocationId = 2,
                    ProductPrice = 50,
                    ProductInStock = "IN",
                },
                new ProductModel
                {
                    ProductId = 3,
                    CategoryId = 3,
                    ProductTitle = "Product 3",
                    ProductImageUrl = "https://picsum.photos/100/50",
                    ProductDescription = "Capture life's precious moments in stunning detail with the QuantumBlaze X3's state-of-the-art triple-camera system. From breathtaking landscapes to vibrant portraits, this device delivers professional-quality photos and videos that will leave you in awe. The innovative AI photography features intelligently enhance your shots, making every picture Instagram-worthy.",
                    ProductLike = true,
                    ProductReview = "Average product",
                    ProductRating = 4,
                    LocationId = 3,
                    ProductPrice = 20,
                    ProductInStock = "IN",
                },
                new ProductModel
                {
                    ProductId = 4,
                    CategoryId = 1,
                    ProductTitle = "Product 4",
                    ProductImageUrl = "https://picsum.photos/100/50",
                    ProductDescription = "Say goodbye to battery anxiety with the QuantumBlaze X3's massive 5000mAh battery. Enjoy all-day usage without worrying about running out of power, and when you do need a boost, the fast-charging capabilities will have you back up and running in no time. Stay connected on the go with 5G connectivity, ensuring speedy downloads and seamless streaming wherever you are.",
                    ProductLike = true,
                    ProductReview = "Average product",
                    ProductRating = 4,
                    LocationId = 3,
                    ProductPrice = 10,
                    ProductInStock = "IN",
                },
                new ProductModel
                {
                    ProductId = 5,
                    CategoryId = 2,
                    ProductTitle = "Product 5",
                    ProductImageUrl = "https://picsum.photos/100/50",
                    ProductDescription = "Security is paramount, and the QuantumBlaze X3 has you covered with its advanced facial recognition and fingerprint sensor technologies. Your data is safeguarded, allowing you to use your device with peace of mind. The sleek and ergonomic design adds a touch of sophistication, making the QuantumBlaze X3 a statement piece that complements your lifestyle.",
                    ProductLike = true,
                    ProductReview = "Average product",
                    ProductRating = 4,
                     LocationId = 1,
                    ProductPrice = 10,
                    ProductInStock = "OUT",
                }
            };

            return dummyProducts;
        }

        // GET api/<ProductController>/5
        [HttpGet("{productId}")]
        public IActionResult GetProduct(int productId)
        {
            var product = new ProductModel()
            {
                ProductId = 4,
                CategoryId = 1,
                ProductTitle = "Product 5",
                ProductImageUrl = "https://picsum.photos/100/100",
                ProductDescription = "Security is paramount, and the QuantumBlaze X3 has you covered with its advanced facial recognition and fingerprint sensor technologies. Your data is safeguarded, allowing you to use your device with peace of mind. The sleek and ergonomic design adds a touch of sophistication, making the QuantumBlaze X3 a statement piece that complements your lifestyle.",
                ProductLike = true,
                ProductReview = "Average product",
                ProductRating = 4,
                LocationId = 1,
                ProductPrice = 10,
                ProductInStock = "IN",
            };
            return Ok(product);
        }

        // GET api/<ProductController>/str
        [HttpGet("searchProducts")]
        public IActionResult SearchProduct(string searchStr)
        {
            var products = new List<ProductModel>()
            {
                 new ProductModel()
                    {
                        ProductId = 4,
                        CategoryId = 1,
                        ProductTitle = "Product 5",
                        ProductImageUrl = "https://picsum.photos/100/100",
                        ProductDescription = "Security is paramount, and the QuantumBlaze X3 has you covered with its advanced facial recognition and fingerprint sensor technologies. Your data is safeguarded, allowing you to use your device with peace of mind. The sleek and ergonomic design adds a touch of sophistication, making the QuantumBlaze X3 a statement piece that complements your lifestyle.",
                        ProductLike = true,
                        ProductReview = "Average product",
                        ProductRating = 4,
                        LocationId = 1,
                        ProductPrice = 10,
                        ProductInStock = "IN",
                    }
            };

            return Ok(products);
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
