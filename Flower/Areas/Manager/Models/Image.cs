using System.ComponentModel.DataAnnotations;

namespace Flower.Areas.Manager.Models
{
    public class Image
    {
        private int image_id;
        private string name;
        private string imagebase64;
        private int flower_id;

        [Key]
        public int Image_id { get => image_id; set => image_id = value; }
        public string Name { get => name; set => name = value; }
        public string Imagebase64 { get => imagebase64; set => imagebase64 = value; }
        public int Flower_id { get => flower_id; set => flower_id = value; }
    }
}
