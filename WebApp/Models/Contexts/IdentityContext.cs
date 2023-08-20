using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Entities;

namespace WebApp.Models.Contexts;

public class IdentityContext : IdentityDbContext
{
    public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
    {
    }

    public DbSet<AccountEntity> Accounts { get; set; }
    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<AccountAddressEntity> AccountAddresses { get; set; }
    public DbSet<OrderEntity> Orders{ get; set; }
    public DbSet<OrderRowEntity> OrderRows { get; set; }
    public DbSet<InvoiceEntity> Invoices { get; set; }
    public DbSet<InvoiceRowEntity> InvoiceRows { get; set; }


}
