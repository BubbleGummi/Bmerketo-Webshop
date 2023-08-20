using WebApp.Models.Entities;

namespace WebApp.Models.Dtos;

public class ProductModel
{
    public int? Id { get; set; }

    public int? TagId { get; set; }
    public string? ArticleNumber { get; set; }
    public string? ProductName { get; set; }
    public string? ProductDescription { get; set; }
    public decimal? Price { get; set; }

    
    public string? ImageUrl { get; set; }
    public CategoryModel Category { get; set; } = null!;

    public ICollection<TagsModel> Tags { get; set; } = new HashSet<TagsModel>();

}
