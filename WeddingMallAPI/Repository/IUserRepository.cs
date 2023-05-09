using WeddingMallWebApp.Models;

namespace WeddingMallAPI.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserById(int id);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        void DeleteUser(int id);

    }
}
