using Flower.Areas.Auther.Models;
using Flower.DAL.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Flower.DAL.Repositorys
{
    public class UserRepository : IUserRepository
    {
        private readonly FlowerDbContext _dbContext;

        public UserRepository(FlowerDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task<User> GetUserByEmail(string email)
        {
            var email_Param = new SqlParameter("@Email", email);
            var users = await _dbContext.users.FromSqlRaw("EXEC GetUserByEmail @Email", email_Param).ToListAsync();
            return users.FirstOrDefault();
        }

        public async Task RegisterUser(User user)
        {
            var full_name_param = new SqlParameter("@FullName", user.Full_name);
            var email_param = new SqlParameter("@Email", user.Email);
            var Password_param = new SqlParameter("@PasswordHash", user.Password_hash);
            var Phone_number_param = new SqlParameter("@PhoneNumber", user.Phone_number);
            var Address_param = new SqlParameter("@Address", user.Address);
            await _dbContext.Database.ExecuteSqlRawAsync("EXEC RegisterUser @FullName, @Email, @PasswordHash, @PhoneNumber, @Address",full_name_param, email_param, Password_param, Phone_number_param, Address_param);
        }

        public async Task UpdateUserRoleAsync(int userId, int roleId)
        {
            var user = await _dbContext.users.FindAsync(userId);
            if (user == null)
                throw new Exception("User not found");

            user.Role_id = roleId;
            await _dbContext.SaveChangesAsync();
        }
    }
}
