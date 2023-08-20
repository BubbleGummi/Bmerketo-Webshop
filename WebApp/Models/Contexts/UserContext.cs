using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Entities;
using WebApp.Models.Identities;

namespace WebApp.Models.Contexts;

public class UserContext : IdentityDbContext<AppUser>
{
    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {
    }

   
    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<UserAddressEntity> UsersAddresses { get; set; }

    
}

