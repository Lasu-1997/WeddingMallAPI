
using Microsoft.EntityFrameworkCore;
using System;
using WeddingMallAPI.Models;

namespace WeddingMallAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly WeddingDBContext weddingDBContext;

        public UserRepository(WeddingDBContext _weddingDBContext)
        {
            weddingDBContext = _weddingDBContext;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await weddingDBContext.User.ToListAsync();
        }
        public async Task<User> GetUserById(int id)
        {
            return await weddingDBContext.User.FindAsync(id);
        }

        public async Task<User> AddUser(User user)
        {
            weddingDBContext.User.Add(user);
            await weddingDBContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            weddingDBContext.Entry(user).State = EntityState.Modified;
            await weddingDBContext.SaveChangesAsync();
            return user;
        }

        public async void DeleteUser(int id)
        {
            var result = await weddingDBContext.User
                .FirstOrDefaultAsync(e => e.Id == id);
            if (result != null)
            {
                weddingDBContext.User.Remove(result);
                await weddingDBContext.SaveChangesAsync();
            }
        }
    }
}
