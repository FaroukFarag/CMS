using CMS.Domain.Interfaces.Repositories.Customers;
using CMS.Domain.Interfaces.UnitOfWork;
using CMS.Infrastructure.Data.Context;

namespace CMS.Infrastructure.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly CMSDbContext _context;

    public ICustomerRepository Customers { get; set; } = default!;

    public UnitOfWork(CMSDbContext context)
    {
        _context = context;
    }

    public async Task Complete()
    {
        await _context.SaveChangesAsync();
    }
}
