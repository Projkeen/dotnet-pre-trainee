namespace Refactor_Bad_Code
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new();
        public void CreateUser(User user) => _users.Add(user);
        public List<User> GetAllUsers() => _users;
        public User? GetUserById(int id) => _users.Find(x => x.Id == id);
    }
}
