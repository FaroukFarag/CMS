using CMS.Domain.Models.Customers;
using Microsoft.AspNetCore.Identity;

namespace CMS.Domain.Models.Users;

public class ApplicationUser : IdentityUser
{
    public int? CustomerId { get; set; } = default!;

    public virtual Customer? Customer { get; set; } = default!;
}
