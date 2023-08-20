namespace WebApp.Models.Entities
{
    public class ContactEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public string? CompanyName { get; set; }

        public string Message { get; set; } = null!;
    }
}
