using MongoDB.Bson;
using MongoDB.Driver;
using userprofileapp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace userprofileapp.Services
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<User> _users;

        // Constructor: Gets the MongoDB collection from the UserProfileDb database
        public UserService(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("UserProfileDb");
            _users = database.GetCollection<User>("Users");
        }

        // Get all users from the Users collection
        public async Task<List<User>> GetAllUsersAsync() =>
            await _users.Find(user => true).ToListAsync();

        // Get a specific user by their ID
        public async Task<User> GetUserByIdAsync(ObjectId id) =>
            await _users.Find(user => user.Id == id).FirstOrDefaultAsync();

        // Create a new user in the Users collection
        public async Task CreateUserAsync(User user) =>
            await _users.InsertOneAsync(user);

        // Update an existing user in the Users collection
        public async Task UpdateUserAsync(User user) =>
            await _users.ReplaceOneAsync(u => u.Id == user.Id, user);
    }
}
