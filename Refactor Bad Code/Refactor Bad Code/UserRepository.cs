using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor_Bad_Code
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new();
        public void CreateUser(User user)
        {
            _users.Add(user);
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }
    }
}
