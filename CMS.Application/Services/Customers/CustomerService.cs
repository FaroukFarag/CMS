using AutoMapper;
using CMS.Application.Dtos.Customers;
using CMS.Application.Interfaces.Customers;
using CMS.Application.Services.Abstraction;
using CMS.Domain.Interfaces.Repositories.Customers;
using CMS.Domain.Interfaces.UnitOfWork;
using CMS.Domain.Models.Customers;

namespace CMS.Application.Services.Customers;

public class CustomerService : BaseService<Customer, CustomerDto>, ICustomerService
{
    public CustomerService(
        ICustomerRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
        : base(repository, unitOfWork, mapper)
    {
    }
}
