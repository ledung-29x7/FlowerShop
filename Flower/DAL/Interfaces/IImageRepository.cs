using Flower.Areas.Manager.Models;

namespace Flower.DAL.Interfaces
{
    public interface IImageRepository
    {
        Task AddImages(List<Image> images);
        Task<List<Image>> GetImageByFlowerId(int flower_id);
        Task DeleteImageByFlowerId(int flower_id);
    }
}
