using medic_api.Models.Domain;

namespace medic_api.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetById(int Id);
        Task BlockUser(User user);
        Task<User> GetUserByUsernameAndPassword(string username, string password);
        Task RegisterUser(User user);
    }
}
