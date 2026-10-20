using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor_Bad_Code
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void RegisterUser(int id, string name, string email, string notificationType)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name is required.");
                return;
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("Email is required.");
                return;
            }

            if (!email.Contains("@"))
            {
                Console.WriteLine("Email is invalid.");
                return;
            }

            // Create user
            var user = new User
            {
                Id = id,
                Name = name,
                Email = email,
                Discount = CalculateDiscount(name)
            };    

            // Save user
            _userRepository.CreateUser(user);
        }

        private int CalculateDiscount(string name)
        {
            if (name.Length > 10)
                return 10;
            else
                return 5;
        }

        public void PrintAllUsers()
        {
            foreach (var user in _userRepository.GetAllUsers())
            {
                Console.WriteLine($"{user.Id} | {user.Name} | {user.Email} | Discount: {user.Discount}%");
            }
        }
    }
}
