using CMS.Domain.Models.Customers;
using CMS.Domain.Models.Users;
using CMS.Infrastructure.Data.ModelsConfigurations.Customers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CMS.Infrastructure.Data.Context;

public class CMSDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<Customer> Customers { get; set; }

    public CMSDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new CustomerConfigurations());
    }
}