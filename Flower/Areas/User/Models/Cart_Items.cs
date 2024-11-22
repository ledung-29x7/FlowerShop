namespace Flower.Areas.User.Models
{
    public class Cart_Items
    {
        private int cart_item_id;
        private int cart_id;
        private int flower_id;
        private int quantity;
        private DateTime added_at;

        public int Cart_item_id { get => cart_item_id; set => cart_item_id = value; }
        public int Cart_id { get => cart_id; set => cart_id = value; }
        public int Flower_id { get => flower_id; set => flower_id = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public DateTime Added_at { get => added_at; set => added_at = value; }
    }
}
