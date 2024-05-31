using CMS.Application.AutoMapper.Abstraction;
using CMS.Application.AutoMapper.Customers;
using CMS.Application.AutoMapper.Users;
using CMS.Application.Interfaces.Customers;
using CMS.Application.Interfaces.Users;
using CMS.Application.Services.Customers;
using CMS.Application.Services.Users;
using CMS.Application.Validators.Customers;
using CMS.Application.Validators.Users;
using CMS.Common.Tokens.Configurations;
using CMS.Common.Tokens.Interfaces;
using CMS.Common.Tokens.Services;
using CMS.Domain.Interfaces.Repositories.Customers;
using CMS.Domain.Interfaces.UnitOfWork;
using CMS.Domain.Models.Users;
using CMS.Infrastructure.Data.Context;
using CMS.Infrastructure.Data.Repositories.Customers;
using CMS.Infrastructure.Data.UnitOfWork;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CMS.Infrastructure.IoC.DependencyContainer;

public static class DependencyContainer
{
    public static void RegisterConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtTokenSettings>(configuration.GetSection(JwtTokenSettings.SectionName));
    }

    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<ICustomerService, CustomerService>()
            .AddScoped<ITokensService, TokensService>()
            .AddScoped<IUserService, UserService>();
    }

    public static void RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CMSDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<CMSDbContext>();
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
        services.AddAutoMapper(typeof(UserProfile).Assembly);
    }

    public static void RegisterValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<CustomerDtoValidator>();
        services.AddValidatorsFromAssemblyContaining<RegisterDtoValidator>();
        services.AddValidatorsFromAssemblyContaining<LoginDtoValidator>();
    }

    public static void RegisterIdentity(this IServiceCollection services)
    {
        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<CMSDbContext>()
            .AddDefaultTokenProviders();
    }

    public static void RegisterJwtSettings(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = configuration.GetSection("JwtTokens");
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings["ValidIssuer"],
                ValidAudience = jwtSettings["ValidAudience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]!)),
                ClockSkew = new TimeSpan(0, 2, 0)
            };
        });
    }
}
