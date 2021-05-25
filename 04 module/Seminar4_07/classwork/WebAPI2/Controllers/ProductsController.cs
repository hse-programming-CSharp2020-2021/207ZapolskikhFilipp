using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebAPI2.Services;

namespace WebAPI2.Controllers
{
	public class ProductsController : Controller
	{
        public ProductsController(JsonFileProductService productService)
        {
            ProductService = productService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(ProductService.GetProducts());
        }
        [Route("product/{id}")]
        public IActionResult Product(string id) => View("ViewItem", ProductService.GetProducts().First(x => x.Id == id));

        public JsonFileProductService ProductService { get; }
    }
}
