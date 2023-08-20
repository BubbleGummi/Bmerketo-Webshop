using Microsoft.EntityFrameworkCore;
using WebApp.Models.Dtos;

namespace WebApp.Models.Entities;

[PrimaryKey("ProductId", "TagId")]
public class ProductTagEntity
{
    public int ProductId { get; set; }
    public ProductEntity Product { get; set; } = null!;


    public int TagId { get; set; }
    public TagEntity Tag { get; set; } = null!;

    public static implicit operator ProductModel(ProductTagEntity? entity)
    {
        return new ProductModel
        {
            Id = entity?.ProductId,
            TagId = entity?.TagId
        };
    }
}
