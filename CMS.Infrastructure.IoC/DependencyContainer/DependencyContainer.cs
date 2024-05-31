using CMS.Application.AutoMapper.Abstraction;
using CMS.Application.AutoMapper.Customers;
using CMS.Application.Interfaces.Customers;
using CMS.Application.Services.Customers;
using CMS.Domain.Interfaces.Repositories.Customers;
using CMS.Domain.Interfaces.UnitOfWork;
using CMS.Infrastructure.Data.Context;
using CMS.Infrastructure.Data.Repositories.Customers;
using CMS.Infrastructure.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CMS.Infrastructure.IoC.DependencyContainer;

public static class DependencyContainer
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<ICustomerService, CustomerService>();
    }

    public static void RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CMSDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
    }

    public static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICustomerRepository, CustomerRepository>();
    }

    public static void RegisterUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    public static void RegisterAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(BaseModelProfile).Assembly);
        services.AddAutoMapper(typeof(CustomerProfile).Assembly);
    }
}
