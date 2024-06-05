using CMS.Application.Dtos.Customers;
using CMS.IntegrationTest.Models;
using CMS.IntegrationTest.Ordering;
using FluentAssertions;


namespace CMS.IntegrationTest.Customers;


[Collection("CMSCollection")]
[TestCaseOrderer("CMS.IntegrationTest.Ordering.PriorityOrderer", "CMS.IntegrationTest.Ordering")]
public class CustomersControllerTests
{
    private CMSFixture _cMSFixture;
    private readonly CustomerDto _customerDto;
    private const string customersController = "Customers";

    public CustomersControllerTests(CMSFixture cMSFixture)
    {
        _cMSFixture = cMSFixture;
        _customerDto = new CustomerDto
        {
            FirstName = "Farouk",
            LastName = "Farag",
            Email = $"farouk.farag{Guid.NewGuid().ToString().Substring(0, 2)}@gmail.com",
            Phone = "01119596006",
            Address = "17 Mohamed Ameen St., El Zeitoun, Cairo"
        };
    }

    [Fact, TestPriority(1)]
    [Trait("Send Remittance", "Ok")]
    public async Task CustomersController_Create_ReturnCustomerDto()
    {
        var customerDto = await _cMSFixture.Act_PostAsync<CustomerDto, CustomerDto>($"{customersController}/Create", _customerDto);

        customerDto.Should().BeOfType<CustomerDto>();
    }
}