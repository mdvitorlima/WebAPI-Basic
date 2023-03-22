using AutoMapper;
using BasicAPI.Data;
using BasicAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace BasicAPI.Service
{
    public class UserService : IUserService
    {

        private readonly DataContext _context;

        private readonly IMapper _mapper;

        public UserService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<User>> GetAllUsers()
        {
            List<User> dbUsers = await _context.Users.ToListAsync();
            return dbUsers;
        }

        public async Task<User> GetUserById(int id)
        {
            User dbUsers = await _context.Users.FirstOrDefaultAsync(c => c.Id == id); ;
            return dbUsers;
        }

        public async Task<List<User>> AddUser(UserDTO user)
        {
            User userObj = _mapper.Map<User>(user);

            await _context.Users.AddAsync(userObj);
            await _context.SaveChangesAsync();
            List<User> listUsers = await _context.Users.ToListAsync();
            return listUsers;
        }

        public async Task<User> UpdateUser(User user)
        {

            User userObj = await _context.Users.FirstOrDefaultAsync(c => c.Id == user.Id);

            userObj.Username = user.Username;

            _context.Users.Update(userObj);

            await _context.SaveChangesAsync();
            return userObj;

        }

        public async Task<User> DeleteUser(int id)
        {
            User user = await _context.Users.FirstAsync(c => c.Id == id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;

        }

    }
}
