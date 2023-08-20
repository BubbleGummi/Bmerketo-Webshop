using Microsoft.AspNetCore.Identity;
using WebApp.Models.Identities;

namespace WebApp.Models.ViewModels
{
    public class UserListViewModel
    {

        public int Id { get; set; }

        public string email { get; set; } = null!;

        public string firstName { get; set; } = null!;

        public string lastName { get; set; } = null!;

        public string roleName { get; set; } = null!;

    }
}
