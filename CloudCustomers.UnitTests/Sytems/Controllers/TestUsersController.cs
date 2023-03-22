using CloudCustomers.API.Controllers;
using CloudCustomers.API.Models;
using CloudCustomers.API.Services;
using CloudCustomers.UnitTests.Fixtures;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CloudCustomers.UnitTests.Sytems.Controllers;

public class TestUsersController
{
    [Fact]
    public async Task Get_OnSuccess_ReturnStatusCode200()
    {
        var mockUsersService = new Mock<IUsersService>();
        mockUsersService
           .Setup(service => service.GetAllUsers())
           .ReturnsAsync(UsersFixture.GetTestUsers());

        var systemUnderTest = new UsersController(mockUsersService.Object);


        var result = (OkObjectResult)await systemUnderTest.Get();


        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task Get_OnSuccess_InvokesUserServiceOnce()
    {

        var mockUsersService = new Mock<IUsersService>();
        mockUsersService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(new List<User>());
        // Arrange
        var systemUnderTest = new UsersController(mockUsersService.Object);

        // Act
        var result = await systemUnderTest.Get();

        // Assert
        mockUsersService.Verify(service => service.GetAllUsers(), Times.Once());
    }


    [Fact]
    public async Task Get_OnSuccess_ReturnsListOfUsers()
    {
        var mockUsersService = new Mock<IUsersService>();
        mockUsersService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(UsersFixture.GetTestUsers());

        var systemUnderTest = new UsersController(mockUsersService.Object);

        var result = await systemUnderTest.Get();

        result.Should().BeOfType<OkObjectResult>();
        var objectResult = (OkObjectResult)result;

        objectResult.Value.Should().BeOfType<List<User>>();
    }

    [Fact]

    public async Task Get_OnNoUsersFound_Returns404()
    {
        var mockUsersService = new Mock<IUsersService>();
        mockUsersService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(new List<User>());

        var systemUnderTest = new UsersController(mockUsersService.Object);

        var result = await systemUnderTest.Get();

        result.Should().BeOfType<NotFoundResult>();

        var objectResult = (NotFoundResult)result;

        objectResult.StatusCode.Should().Be(404);
    }

    //[Fact]
    //public async Task Get_OnNoUsersFound_ReturnStatusCode200()
    //{
    //    var mockUsersService = new Mock<IUsersService>();
    //    mockUsersService
    //       .Setup(service => service.GetAllUsers())
    //       .ReturnsAsync(new List<User>());

    //    var systemUnderTest = new UsersController(mockUsersService.Object);


    //    var result = (OkObjectResult)await systemUnderTest.Get();


    //    result.StatusCode.Should().Be(200);
    //}


}