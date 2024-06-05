using CMS.Domain.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace CMS.Infrastructure.Data.Seeding;

public static class DataSeeder
{
    public static async Task SeedUserData(IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager)
    {
        var defaultUser = new ApplicationUser
        {
            UserName = "admin@cms.com",
            Email = "admin@cms.com",
            EmailConfirmed = true,
        };

        string userPassword = "Admin123!";
        var user = await userManager.FindByEmailAsync(defaultUser.Email);

        if (user == null)
        {
            var createPowerUser = await userManager.CreateAsync(defaultUser, userPassword);
            if (!createPowerUser.Succeeded)
            {
                throw new Exception("Couldn't Seed the Admin User!");
            }
        }
    }
}
