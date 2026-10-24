namespace Refactor_Bad_Code
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserValidation _userValidation;
        private readonly IEnumerable<INotificationSender> _notificationSender;
        private readonly ILogging _logging;

        public UserService(IUserRepository userRepository, UserValidation userValidation, IEnumerable<INotificationSender> notificationSender, ILogging logging)
        {
            _userRepository = userRepository;
            _userValidation = userValidation;
            _notificationSender = notificationSender;
            _logging = logging;
        }

        public void RegisterUser(int id, string name, string email, string notificationType)
        {
            var checkExist = _userValidation.CheckRegisterValidation(name, email);
            if (checkExist != null)
            {
                Console.WriteLine("Smthng wrong");
                return;
            }

            var user = new User
            {
                Id = id,
                Name = name,
                Email = email,
                Discount = CalculateDiscount(name)
            };

            _userRepository.CreateUser(user);
            PrintNotification(user, notificationType);
            _logging.Log($"LOG: User {name} was registered at {DateTime.Now}");
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

        public void UpdateEmail(int userId, string email)
        {
            var checkExist = _userValidation.CheckEmailValidation(email);
            if (checkExist != null)
            {
                Console.WriteLine("Smthng wrong");
                return;
            }

            var user = _userRepository.GetUserById(userId);

            if (user == null)
            {
                Console.WriteLine("User not found");
                return;
            }

            user.Email = email;
            _logging.Log($"LOG: Email for user {user.Name} was changed.");
        }

        private void PrintNotification(User user, string notificationType)
        {
            var notificationSender = _notificationSender.FirstOrDefault(n => n.Type == notificationType);
            if (notificationSender != null)
                notificationSender.SendNotification(user);
            else
                Console.WriteLine("Unknown notification");
        }
    }
}
