using eshop.Models;
using eshop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eshop.Controllers
{
    [Authorize(Roles = "Admin, Editor")]
    public class ProductsController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            var products = productService.GetProducts();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.categories = getCategories();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if(ModelState.IsValid)
            {
                productService.AddProduct(product);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.categories = getCategories();
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = productService.FindProduct(id);
            ViewBag.categories = getCategories();
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if(ModelState.IsValid)
            {
                productService.Update(product);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.categories = getCategories();
            return View(product);
        }
        private IEnumerable<SelectListItem> getCategories()
        {
            var categories = categoryService.GetCategories();
            return categories.Select(cat => new SelectListItem { Text = cat.Name, Value = cat.Id.ToString() });
        }
    }
}
