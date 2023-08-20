using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models.ViewModels;
using WebApp.Services;

namespace WebApp.Controllers;

[Authorize(Roles ="admin")]
public class AdminController : Controller
{
    

    private readonly ProductService _productService;
    private readonly TagService _tagService;
    public AdminController(ProductService productService, TagService tagService)
    {
        _productService = productService;
        _tagService = tagService;
    }

    public async Task<IActionResult> Products()
    {
        var products = await _productService.GetProductAsync();  
        return View(products);
    }

    //domain.com/admin
    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> CreateProductAsync()
    {
        ViewBag.Tags = await _tagService.GetTagsAsync();
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> CreateProductAsync(CreateProductViewModel createProductViewModel, string[] tags)
    {
        if (ModelState.IsValid)
        {
            if (await _productService.CreateProductAsync(createProductViewModel))
            {
                await _productService.AddProductTagsAsync(createProductViewModel, tags);
                return RedirectToAction("CreateProduct", "Admin");
            }
                

            ModelState.AddModelError("", "Something went wrong, please try again");
        }
        ViewBag.Tags = await _tagService.GetTagsAsync(tags);
        return View(createProductViewModel);
    }


    public IActionResult Users()
    {
        return View();
    }

}