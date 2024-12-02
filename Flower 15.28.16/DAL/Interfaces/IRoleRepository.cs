using Flower.Areas.Auther.Models;

namespace Flower.DAL.Interfaces
{
    public interface IRoleRepository
    {
        Task<Role> GetRoleById(int roleId);
    }
}
