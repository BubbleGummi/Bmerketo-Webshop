namespace WebApp.Models.Dtos;

public class TagsModel
{
    public int TagId { get; set; }
    public string TagName { get; set; } = null!;
    public int ProductId { get; set; }
}
