using CloudCustomers.API.Models;

namespace CloudCustomers.UnitTests.Fixtures;
public static class UsersFixture
{
    public static List<User> GetTestUsers() =>

        new()
        {
            new User {
                Name = "Test1",
                Email = "test1.user@prodDev.com",
                Address = new Address
                {
                    Street = "123 av str",
                    Zipcode = 54872,
                    City = "Somewhere"
                }
                },
             new User {
                Name = "Test2",
                Email = "test2.user@prodDev.com",
                Address = new Address
                {
                    Street = "123 av str",
                    Zipcode = 54872,
                    City = "Somewhere"
                }
                },

             new User {
                Name = "Test3",
                Email = "test3.user@prodDev.com",
                Address = new Address
                {
                    Street = "123 av str",
                    Zipcode = 54872,
                    City = "Somewhere"
                }
            }
        };
}





