using CloudCustomers.API.Services;



namespace CloudCustomers.UnitTests.Sytems.Services;
public class TestUsersService
{
    [Fact]
    public async Task GetAllUsers_WhenInvoked_InvokesHttpGetRequest()
    {
        var systemUnderTest = new UsersService();

        await systemUnderTest.GetAllUsers(); 
    }
}

