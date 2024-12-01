namespace Flower.Areas.Dtos
{
    public class UpdateFlowerDto
    {
        public int FlowerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Occasion_id { get; set; }
        public int Stock { get; set; }
    }
}
