using CMS.Application.Dtos.Customers;
using CMS.Application.Interfaces.Customers;
using CMS.WebApi.Controllers;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace CMS.UnitTest.Customers;

public class CustomersControllerTests
{
    private readonly ICustomerService _service;
    private readonly CustomersController _controller;
    private readonly CustomerDto _customerDto;

    public CustomersControllerTests()
    {
        _service = A.Fake<ICustomerService>();
        _controller = new CustomersController(_service);
        _customerDto = new CustomerDto
        {
            FirstName = "Farouk",
            LastName = "Farag",
            Email = "farouk.farag98@gmail.com",
            Phone = "01119596006",
            Address = "17 Mohamed Ameen St., El Zeitoun, Cairo"
        };
    }

    [Fact]
    public async Task CustomersController_Create_ReturnOk()
    {
        A.CallTo(() => _service.CreateAsync(_customerDto)).Returns(Task.FromResult(_customerDto));

        var result = await _controller.Create(_customerDto) as OkObjectResult;

        result.Should().NotBeNull();
        result?.StatusCode.Should().Be(200);
        result?.Value.Should().BeEquivalentTo(_customerDto);
    }

    [Fact]
    public async Task CustomersController_Get_ReturnOk()
    {
        var id = 1;

        _customerDto.Id = id;

        A.CallTo(() => _service.GetAsync(id))
            .Returns(Task.FromResult(_customerDto));

        var result = await _controller.Get(id);

        result.Should().NotBeNull();
        result.Should().BeOfType<OkObjectResult>();

        var okResult = result as OkObjectResult;

        okResult?.Value.Should().BeEquivalentTo(_customerDto);
    }

    [Fact]
    public async Task CustomersController_GetAll_ReturnOk()
    {
        var customers = A.Fake<IEnumerable<CustomerDto>>();

        var result = await _controller.GetAll();

        result.Should().NotBeNull();
        result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public async Task CustomersController_Update_ReturnOk()
    {
        var id = 1;

        _customerDto.Id = id;

        A.CallTo(() => _service.Update(_customerDto))
            .Returns(Task.FromResult(_customerDto));

        var result = await _controller.Update(_customerDto);

        result.Should().NotBeNull();
        result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public async Task CustomersController_Delete_ReturnOk()
    {
        var id = 1;

        A.CallTo(() => _service.Delete(id))
            .Returns(Task.FromResult(_customerDto));

        var result = await _controller.Delete(id);

        result.Should().NotBeNull();
        result.Should().BeOfType<OkObjectResult>();
    }
}
