using BlogAPI.Models;

namespace BlogAPI.Interfaces
{
    public interface IUserServices
    {
        Task<List<User>> GetUsers();
        Task<User?> GetUserById(int id);
        Task<User?> AddUser(AddUpdateUser newUser);
        Task<User?> UpdateUser(int id, AddUpdateUser updatedUser);
        Task<bool> DeleteUser(int id);
    }
}
