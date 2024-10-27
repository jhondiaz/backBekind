using MongoDB.Driver;
using testBekind.Domain;
using testBekind.Domain.Interfaces;
using testBekindService.DataContexts;

namespace testBekindService.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MongoContext _context;

        public UserRepository(MongoContext context)
        {

            _context = context;

        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.Find(_ => true).ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            return await _context.Users.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByNameAsync(string name)
        {
            return await _context.Users.Find(p => p.Name == name).FirstOrDefaultAsync();
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.InsertOneAsync(user);
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            var result = await _context.Users.ReplaceOneAsync(p => p.Id == user.Id, user);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> DeleteUserAsync(string id)
        {
            var result = await _context.Users.DeleteOneAsync(p => p.Id == id);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }

       
    }




}
