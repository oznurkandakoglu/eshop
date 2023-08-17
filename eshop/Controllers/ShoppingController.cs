using eshop.Application.Services;
using eshop.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace eshop.Controllers
{
    public class ShoppingController : Controller
    {
        private readonly IProductService productService;

        public ShoppingController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Index()
        {
            var collection = getCollectionFromSession();

            return View(collection);
        }
        public IActionResult AddToCard(int id)
        {
            
            var product = productService.FindProduct(id);

            ShoppingCollection shoppingCollection = getCollectionFromSession();
            ProductItem productItem = new ProductItem { Product = product, Quantity = 1};
            shoppingCollection.Add(productItem);
            saveCollectionToSession(shoppingCollection);

            return Json(new { message = $"{product.Name} isimli ürün sepete eklendi." });
        }

        private void saveCollectionToSession(ShoppingCollection shoppingCollection)
        {
            var serializedToJson = JsonConvert.SerializeObject(shoppingCollection);
            HttpContext.Session.SetString("sepet", serializedToJson);
        }

        private ShoppingCollection getCollectionFromSession()
        {
            string json = HttpContext.Session.GetString("sepet");
            if (!string.IsNullOrEmpty(json))
            {
                var collection = JsonConvert.DeserializeObject<ShoppingCollection>(json);
                return collection;
            }
            
            return new ShoppingCollection();

        }
    }
}
