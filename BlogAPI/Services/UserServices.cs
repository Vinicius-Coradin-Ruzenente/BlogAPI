using BlogAPI.Interfaces;
using BlogAPI.Models;
using BlogAPI.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Services
{
    public class UserServices(BlogAPIDbContext db) : IUserServices
    {
        private readonly BlogAPIDbContext _db = db;

        public async Task<List<User>> GetUsers()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<User?> GetUserById(int id)
        {
            return await _db.Users.FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task<User?> AddUser(AddUpdateUser newUser)
        {
            var user = new User
            {
                Name = newUser.Name,
                Username = newUser.Username,
                Password = newUser.Password,
            };
            _db.Users.Add(user);
            var result = await _db.SaveChangesAsync();
            return result > 0 ? user : null;
        }

        public async Task<User?> UpdateUser(int id, AddUpdateUser updatedUser)
        {
            var user = await _db.Users.FirstOrDefaultAsync(user => user.Id == id);
            if (user != null)
            {
                user.Name = updatedUser.Name;
                user.Username = updatedUser.Username;
                user.Password = updatedUser.Password;

                var result = await _db.SaveChangesAsync();
                return result > 0 ? user : null;
            }
            return null;            
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _db.Users.FirstOrDefaultAsync(user => user.Id == id);
            if (user != null)
            {
                _db.Users.Remove(user);
                var result = await _db.SaveChangesAsync();
                return result >= 0;
            }
            return false;
        }
    }
}
