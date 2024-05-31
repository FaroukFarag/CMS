using CMS.Domain.Interfaces.Repositories.Customers;
using CMS.Domain.Models.Customers;
using CMS.Infrastructure.Data.Context;
using CMS.Infrastructure.Data.Repositories.Abstraction;

namespace CMS.Infrastructure.Data.Repositories.Customers;

public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(CMSDbContext context) : base(context)
    {
    }
}
