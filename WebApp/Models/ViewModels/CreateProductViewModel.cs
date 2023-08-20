using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;

namespace WebApp.Models.ViewModels;

public class CreateProductViewModel
{
    [Required(ErrorMessage = "You must name the product")]
    [Display(Name = "Product Name *")]
    public string ProductName { get; set; } = null!;

    [Required(ErrorMessage = "Product must have an articlenumber")]
    [Display(Name = "Product Article number")]
    public string ArticleNumber { get; set; } = null!;

    [Display(Name = "Product Description")]
    public string? ProductDescription { get; set; }



    [Required(ErrorMessage = "The product needs a price")]
    [Display(Name = "Product Price")]
    public decimal Price { get; set; }



    [Required(ErrorMessage = "You must provide an Image Url")]
    [Display(Name = "Product Image")]
    public string ImageUrl { get; set; } = null!;




    [Required(ErrorMessage = "You must place the product in a category")]
    [Display(Name = "Product Category")]

    public int CategoryId { get; set; }


    public static implicit operator ProductEntity(CreateProductViewModel createProductViewModel)
    {
        return new ProductEntity
        {
            ProductName = createProductViewModel.ProductName,
            ProductDescription = createProductViewModel.ProductDescription,
            ArticleNumber = createProductViewModel.ArticleNumber,
            Price = createProductViewModel.Price,
            ImageUrl = createProductViewModel.ImageUrl,
            CategoryId = createProductViewModel.CategoryId,

        };
    }


}
