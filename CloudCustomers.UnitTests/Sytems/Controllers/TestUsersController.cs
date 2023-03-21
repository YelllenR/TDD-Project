using CloudCustomers.API.Controllers;
using CloudCustomers.API.Models;
using CloudCustomers.API.Services;
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
           .ReturnsAsync(new List<User>());

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
}