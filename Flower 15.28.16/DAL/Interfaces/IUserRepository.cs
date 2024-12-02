using Flower.Areas.Auther.Models;

namespace Flower.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task RegisterUser(User user);
        Task<User> GetUserByEmail(string email);
        Task UpdateUserRoleAsync(int userId, int roleId);
    }
}
