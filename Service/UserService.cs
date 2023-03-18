using BasicAPI.Data;
using BasicAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace BasicAPI.Service
{
    public class UserService : IUserService
    {

        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetAllUsers()
        {
            List<User> dbUsers = await _context.Users.ToListAsync();
            return dbUsers;
        }

    }
}
