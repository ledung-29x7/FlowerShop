namespace Flower.Areas.Dtos
{
    public class CreateImageFileDto
    {
        public int FlowerId { get; set; }
        public List<IFormFile> Files { get; set; }
    }
}
