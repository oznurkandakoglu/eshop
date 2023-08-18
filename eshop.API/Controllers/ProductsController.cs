using eshop.Application.Services;
using eshop.Infrastructure.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = productService.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = productService.FindProduct(id);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);

        }

        [HttpGet("[action]/{name}")]
        public IActionResult SearchByName(string name)
        {
            var products = productService.SearchByName(name);
            return Ok(products);
        }

        [HttpPost]
        public IActionResult CreateNewProdct(Product product)
        {
            if(ModelState.IsValid)
            {
                productService.AddProduct(product);
                return CreatedAtAction(nameof(GetProduct), routeValues: new {id = product.Id}, value: null);
            }
            return BadRequest(ModelState); 
        }
    }
}
