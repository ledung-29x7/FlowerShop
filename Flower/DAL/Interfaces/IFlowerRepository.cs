using Flower.Areas.Admin.Models;
using Flower.Areas.Dtos;
using Flower.Areas.Manager.Models;

namespace Flower.DAL.Interfaces
{
    public interface IFlowerRepository
    {
        Task CreateFlower(Flowers flowers);
        Task<List<Flowers>> GetFlower();
        Task<FlowerDetailDto> GetFlowerById(int flower_id);
        Task UpdateFlower(FlowerDetailDto flowers);
        Task DeleteFlower(int flower_id);
    }
}
