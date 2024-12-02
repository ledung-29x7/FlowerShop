using Flower.Areas.Admin.Models;
using Flower.Areas.Dtos;
using Flower.DAL.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Flower.DAL.Repositorys
{
    public class OccasionRepository : IOccasionRepository
    {
        private readonly FlowerDbContext _dbContext;

        public OccasionRepository(FlowerDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task CreateOccasion(Occasion occasion)
        {
            var name_param = new SqlParameter("@Name", occasion.Name);
            var description_param = new SqlParameter("@Description", occasion.Description);
            await _dbContext.Database.ExecuteSqlRawAsync("EXECUTE dbo.CreateOccasion @Name, @Description", name_param, description_param);
        }

        public async Task DeleteOccasion(int occasion_id)
        {
            var id_Param = new SqlParameter("@Occasion_id", occasion_id);
            await _dbContext.Database.ExecuteSqlRawAsync("EXECUTE dbo.DeleteOccasion @Occasion_id", id_Param);
        }

        public async Task<List<Occasion>> GetOccasion()
        {
            return await Task.FromResult(_dbContext.occasions.FromSqlRaw("EXECUTE dbo.GetAllOccasion").ToList());
        }

        public async Task<Occasion> GetOccasionById(int occasion_id)
        {
            var id_Param = new SqlParameter("@Occasion_id", occasion_id);
            var occasions = await _dbContext.occasions
                .FromSqlRaw("EXECUTE dbo.GetOccasionById @Occasion_id", id_Param)
                .ToListAsync();
            return occasions.FirstOrDefault();
        }

        public async Task UpdateOccasion(Occasion occasion)
        {
            var id_Param = new SqlParameter("@Occasion_id", occasion.Occasion_id);
            var name_param = new SqlParameter("@Name", occasion.Name);
            var description_param = new SqlParameter("@Description", occasion.Description);
            await _dbContext.Database.ExecuteSqlRawAsync("EXECUTE dbo.UpdateOccasion @Occasion_id, @Name, @Description", id_Param, name_param, description_param);
        }
    }
}