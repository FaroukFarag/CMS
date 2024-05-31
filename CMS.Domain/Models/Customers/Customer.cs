using CMS.Domain.Models.Abstraction;
using CMS.Domain.Models.Users;

namespace CMS.Domain.Models.Customers;

public class Customer : BaseModel
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Phone { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string UserId { get; set; } = default!;

    public virtual ApplicationUser User { get; set; } = default!;
}
