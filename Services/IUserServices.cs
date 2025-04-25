using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;
using userprofileapp.Models;

namespace userprofileapp.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(ObjectId id);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
    }
}
