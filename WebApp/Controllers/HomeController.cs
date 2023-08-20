using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Contexts;
using WebApp.Models.Dtos;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductService _productService;

        public HomeController(ProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            List<ProductModel> product;
            product = (List<ProductModel>)await _productService.GetAllAsync();


            return View(product);
        }
    }
}
