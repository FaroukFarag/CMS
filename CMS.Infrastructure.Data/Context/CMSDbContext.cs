using CMS.Domain.Models.Customers;
using CMS.Infrastructure.Data.ModelsConfigurations.Customers;
using Microsoft.EntityFrameworkCore;

namespace CMS.Infrastructure.Data.Context;

public class CMSDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }

    public CMSDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerConfigurations());
    }
}