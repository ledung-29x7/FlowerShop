using Flower.Areas.Auther.Models;
using Flower.DAL.Interfaces;

namespace Flower.DAL.Repositorys
{
    public class RoleRepository : IRoleRepository
    {
        private readonly FlowerDbContext _dbContext;

        public RoleRepository(FlowerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Role> GetRoleById(int roleId)
        {
            return await _dbContext.roles.FindAsync(roleId);
        }
    }
}
