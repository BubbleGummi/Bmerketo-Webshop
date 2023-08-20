using Microsoft.AspNetCore.Mvc;
using WebApp.Models.ViewModels;
using WebApp.Services;

namespace WebApp.Controllers;

public class ProductsController : Controller
{
    private readonly ProductService _productService;

    public ProductsController(ProductService productService)
    {
        _productService = productService;
    }

    public IActionResult Index()
    {
        return View();
    }


    public async Task<IActionResult> Details(string productName)
    {
        var product = await _productService.GetProductAsync(productName);
        return View(product);
    }
}
