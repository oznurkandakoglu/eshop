using eshop.Models;

namespace eshop.Services
{
    public class UserService : IUserService
    {
        private List<User> users = new List<User>();

        public UserService()
        {
            users = new List<User>()
            {
                new(){Id = 1, UserName="oznur", Password="123", Role="Admin", Name="Öznur", Email="o@bc.com"},
                new(){Id = 2, UserName="sina", Password="123", Role="Customer", Name="Sina", Email="s@bc.com"},
                new(){Id = 3, UserName="enes", Password="123", Role="Editor", Name="Enes", Email="e@bc.com"},
            };
        }
        public User ValidateUser(string username, string password)
        {
            return users.FirstOrDefault(u => u.UserName == username && u.Password == password);
        }
    }
}
