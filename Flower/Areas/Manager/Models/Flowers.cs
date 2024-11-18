using System.ComponentModel.DataAnnotations;

namespace Flower.Areas.Manager.Models
{
    public class Flowers
    {
        private int flower_id;
        private string name;
        private string description;
        private decimal price;
        private int occasion_id;
        private int stock;
        private DateTime? created_at;
        private bool? is_active;

        [Key]
        public int Flower_id { get => flower_id; set => flower_id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public decimal Price { get => price; set => price = value; }
        public int Occasion_id { get => occasion_id; set => occasion_id = value; }
        public int Stock { get => stock; set => stock = value; }
        public DateTime? Created_at { get => created_at; set => created_at = value; }
        public bool? Is_active { get => is_active; set => is_active = value; }
    }
}
