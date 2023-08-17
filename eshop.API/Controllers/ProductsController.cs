using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var products = new String[] { "p1", "p2", "p3" };
            return Ok(products);
        }
    }
}
