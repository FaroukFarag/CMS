using CMS.Domain.Interfaces.Repositories.Customers;

namespace CMS.Domain.Interfaces.UnitOfWork;

public interface IUnitOfWork
{
    public ICustomerRepository Customers { get; set; }

    Task Complete();
}