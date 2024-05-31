using CMS.Application.Dtos.Abstraction;

namespace CMS.Application.Dtos.Customers;

public class CustomerDto : BaseModelDto
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Phone { get; set; } = default!;
    public string Address { get; set; } = default!;
}
