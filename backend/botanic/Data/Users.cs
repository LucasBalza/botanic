using botanic.Models;

namespace botanic.Data
{
    public class Users
    {

        public static List<User> usersList = new List<User>()
        {
            new User() { 
                Id = 1,
                Username = "lucas", 
                GivenName = "lucas", 
                Surname="lucas",
                Email = "lucas.admin@email.com", 
                Password = "password", 
                Role = "Administrator" 
            },
        };

    }
}
