namespace Flower.Areas.User.Models
{
    public class Order_Items
    {
        private int order_item_id;
        private int order_id;
        private int flower_id;
        private int quantity;
        private decimal unit_price;
        private decimal total_price;

        public int Order_item_id { get => order_item_id; set => order_item_id = value; }
        public int Order_id { get => order_id; set => order_id = value; }
        public int Flower_id { get => flower_id; set => flower_id = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public decimal Unit_price { get => unit_price; set => unit_price = value; }
        public decimal Total_price { get => total_price; set => total_price = value; }
    }
}
