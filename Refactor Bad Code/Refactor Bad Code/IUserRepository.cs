using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor_Bad_Code
{
    public interface IUserRepository
    {
        void CreateUser(User user);
        List<User> GetAllUsers();
    }
}
