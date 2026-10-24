namespace Refactor_Bad_Code
{
    public interface IUserRepository
    {
        void CreateUser(User user);
        List<User> GetAllUsers();
        User? GetUserById(int id);
    }
}
