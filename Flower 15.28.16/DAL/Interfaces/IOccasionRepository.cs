using Flower.Areas.Admin.Models;
using Flower.Areas.Dtos;

namespace Flower.DAL.Interfaces
{
    public interface IOccasionRepository
    {
        Task CreateOccasion(Occasion occasion);
        Task<List<Occasion>> GetOccasion();
        Task<Occasion> GetOccasionById(int occasion_id);
        Task UpdateOccasion(Occasion occasion);
        Task DeleteOccasion(int occasion_id);
    }
}
