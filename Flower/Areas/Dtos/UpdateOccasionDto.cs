namespace Flower.Areas.Dtos
{
    public class UpdateOccasionDto
    {
        public int OccasionId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
