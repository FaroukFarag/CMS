using CMS.Domain.Interfaces.Repositories.Customers;

namespace CMS.Domain.Interfaces.UnitOfWork;

public interface IUnitOfWork
{
    public ICustomerRepository Categories { get; set; }

    Task Complete();
}