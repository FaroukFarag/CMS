using AutoMapper;
using CMS.Application.Dtos.Customers;
using CMS.Domain.Models.Customers;

namespace CMS.Application.AutoMapper.Customers;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CustomerDto>().ReverseMap();
    }
}
