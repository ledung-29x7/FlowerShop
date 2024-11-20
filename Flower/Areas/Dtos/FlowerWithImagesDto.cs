namespace Flower.Areas.Dtos
{
    public class FlowerWithImagesDto
    {
        public string FlowerName { get; set; }
        public string FlowerDescription { get; set; }
        public int OccasionId { get; set; }
        public decimal FlowerPrice { get; set; }
        public int FlowerStock { get; set; }
        public int FlowerId { get; set; }
        public bool IsActive { get; set; }
        public string ImageBase64 { get; set; }
        public string ImageName { get; set; }
    }
}
