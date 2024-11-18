using Flower.Areas.Admin.Models;
using Flower.Areas.Manager.Models;

namespace Flower.DAL.Interfaces
{
    public interface IFlowerRepository
    {
        Task CreateFlower(Flowers flowers);
        Task<List<Flowers>> GetFlower();
        Task<Flowers> GetFlowerById(int flower_id);
        Task UpdateFlower(Flowers flowers);
        Task DeleteFlower(int flower_id);
    }
}
