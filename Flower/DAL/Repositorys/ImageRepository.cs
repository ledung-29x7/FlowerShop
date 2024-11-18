using Flower.Areas.Manager.Models;
using Flower.DAL.Interfaces;

namespace Flower.DAL.Repositorys
{
    public class ImageRepository : IImageRepository
    {
        private readonly FlowerDbContext _context;
        public ImageRepository(FlowerDbContext context)
        {
            _context = context;
        }
        public Task AddImages(List<Image> images)
        {
            throw new NotImplementedException();
        }

        public Task DeleteImage(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Image>> GetImageByFlowerId(int flower_id)
        {
            throw new NotImplementedException();
        }
    }
}
