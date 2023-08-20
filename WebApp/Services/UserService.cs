using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Contexts;
using WebApp.Models.Identities;

namespace WebApp.Services
{
    public class UserService
    {
        private readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IEnumerable<(string email, string firstName, string lastName, string roleName)>> GetAllUsersWithRolesAsync()
        {
            var userAndRole = new List<(string email, string firstName, string lastName, string roleName)>();
            var users = await _userManager.Users.ToListAsync();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var roleName = roles.FirstOrDefault();

                userAndRole.Add((
                    email: user.Email ?? "",   
                    firstName: user.FirstName,
                    lastName: user.LastName,
                    roleName: roleName ?? ""      
                ));
            }

            return userAndRole;
        }
    }

}
