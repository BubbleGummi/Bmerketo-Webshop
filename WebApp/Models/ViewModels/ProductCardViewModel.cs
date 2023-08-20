namespace WebApp.Models.ViewModels
{
    public class ProductCardViewModel
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public decimal Price { get; set; }
        public int Id { get; set; }

        public string? Category { get; set; }
    }
}
