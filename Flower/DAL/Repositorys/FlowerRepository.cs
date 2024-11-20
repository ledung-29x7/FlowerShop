using AutoMapper;
using Flower.Areas.Admin.Models;
using Flower.Areas.Dtos;
using Flower.Areas.Manager.Models;
using Flower.DAL.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Flower.DAL.Repositorys
{
    public class FlowerRepository : IFlowerRepository
    {
        private readonly FlowerDbContext _dbContext;
        private readonly IMapper _mapper;

        public FlowerRepository(FlowerDbContext dbContext, IMapper mapper) 
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task CreateFlower(Flowers flowers)
        {
            var name_param = new SqlParameter("@Name", flowers.Name);
            var Description_param = new SqlParameter("@Description", flowers.Description);
            var Price_param = new SqlParameter("@Price", flowers.Price);
            var Occasion_id_param = new SqlParameter("@Occasion_id", flowers.Occasion_id);
            var Stock_param = new SqlParameter("@Stock", flowers.Stock);
            await _dbContext.Database.ExecuteSqlRawAsync("EXECUTE dbo.CreateFlower @Name, @Description, @Price, @Occasion_id, @Stock", name_param, Description_param, Price_param, Occasion_id_param, Stock_param);

        }

        public async Task DeleteFlower(int flower_id)
        {
            var id_Param = new SqlParameter("@Flower_id", flower_id);
            await _dbContext.Database.ExecuteSqlRawAsync("EXECUTE dbo.DeleteFlower @Flower_id", id_Param);
        }

        public async Task<List<Flowers>> GetFlower()
        {
            return await Task.FromResult(_dbContext.flowers.FromSqlRaw("EXECUTE dbo.GetFlower").ToList());
        }

        public async Task<FlowerDetailDto?> GetFlowerById(int flower_id)
        {
            var idParam = new SqlParameter("@Flower_id", flower_id);

            var result = await _dbContext.Set<FlowerWithImagesDto>()
                .FromSqlRaw("EXECUTE dbo.GetFlowerById @Flower_id", idParam)
                .ToListAsync();

            if (!result.Any()) return null;

            // Dùng AutoMapper để ánh xạ dữ liệu
            var flowerDetailDto = _mapper.Map<FlowerDetailDto>(result.First());

            // Ánh xạ thủ công danh sách hình ảnh
            flowerDetailDto.Images = _mapper.Map<List<ImageDto>>(
                result.Where(r => !string.IsNullOrEmpty(r.ImageName))
            );


            return flowerDetailDto;
        }

        public async Task UpdateFlower(FlowerDetailDto flowers)
        {
            var id_Param = new SqlParameter("@Flower_id", flowers.Id);
            var name_param = new SqlParameter("@Name", flowers.Name);
            var description_param = new SqlParameter("@Description", flowers.Description);
            var Price_param = new SqlParameter("@Price", flowers.Price);
            var Occasion_id_param = new SqlParameter("@Occasion_id", flowers.Occasion_id);
            var Stock_param = new SqlParameter("@Stock", flowers.Stock);

            await _dbContext.Database.ExecuteSqlRawAsync("EXECUTE dbo.UpdateFlower @Flower_id, @Name, @Description, @Price, @Occasion_id, @Stock", id_Param, name_param, description_param, Price_param, Occasion_id_param, Stock_param);
        }
    }
}
