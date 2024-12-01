using Flower.Areas.Auther.Models;

namespace Flower.DAL.Interfaces
{
    public interface IAuthService
    {
        string GenerateJwtToken(User user, string roleName);
        
    }
}
