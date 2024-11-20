using Flower.Areas.Manager.Models;

namespace Flower.Areas.Dtos
{
    public class FlowerDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Occasion_id { get; set; }
        public int Stock { get; set; }
        public List<ImageDto> Images { get; set; }
    }
    public class ImageDto
    {
        public string Name { get; set; }
        public string Base64 { get; set; }
    }
}
