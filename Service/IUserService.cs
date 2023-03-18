using BasicAPI.Entities;

namespace BasicAPI.Service
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
    }
}
