using Microsoft.AspNetCore.Mvc;
using Walsh.Product.Management.Service.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Walsh.Product.Management.Service.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        // GET: api/<ProductLocationController>
        [HttpGet]
        public List<ProductLocationModel> Get() 
        {
            var dummyCategories = new List<ProductLocationModel>() {
                new ProductLocationModel(){
                        LocationId = 1,
                        LocationName = "Montreal"
                        },
                        new ProductLocationModel(){
                        LocationId = 2,
                        LocationName = "Gatineau"
                        },
                        new ProductLocationModel(){
                        LocationId = 3,
                        LocationName = "Sherbrooke"
                   }
            };  
            return dummyCategories;
        }
    }
}
