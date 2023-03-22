using BasicAPI.Entities;

namespace BasicAPI.Service
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<List<User>> AddUser(UserDTO user);
        Task<User> UpdateUser(User user);
        Task<User> DeleteUser(int id);
    }
}
