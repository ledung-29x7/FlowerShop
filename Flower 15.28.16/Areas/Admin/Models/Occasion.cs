using System.ComponentModel.DataAnnotations;

namespace Flower.Areas.Admin.Models
{
    public class Occasion
    {
        private int occasion_id;
        private string name;
        private string description;

        [Key]
        public int Occasion_id { get => occasion_id; set => occasion_id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
    }
}
