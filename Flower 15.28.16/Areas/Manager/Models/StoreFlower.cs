namespace Flower.Areas.Manager.Models
{
    public class StoreFlower
    {
        private int store_flower_id;
        private int store_id;
        private int flower_id;
        private int quantity;
        private DateTime last_updated;

        public int Store_flower_id { get => store_flower_id; set => store_flower_id = value; }
        public int Store_id { get => store_id; set => store_id = value; }
        public int Flower_id { get => flower_id; set => flower_id = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public DateTime Last_updated { get => last_updated; set => last_updated = value; }
    }
}
