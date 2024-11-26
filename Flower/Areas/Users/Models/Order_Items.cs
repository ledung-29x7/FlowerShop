namespace Flower.Areas.Users.Models
{
    public class Order_Items
    {
        private int order_item_id;
        private int order_id;
        private int flower_id;
        private int quantity;
        private decimal unit_price;
        private decimal total_price;
        private string recipient_name;
        private string recipient_address;
        private string recipient_phone;
        private DateTime delivery_time;

        public int Order_item_id { get => order_item_id; set => order_item_id = value; }
        public int Order_id { get => order_id; set => order_id = value; }
        public int Flower_id { get => flower_id; set => flower_id = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public decimal Unit_price { get => unit_price; set => unit_price = value; }
        public decimal Total_price { get => total_price; set => total_price = value; }
        public string Recipient_name { get => recipient_name; set => recipient_name = value; }
        public string Recipient_address { get => recipient_address; set => recipient_address = value; }
        public string Recipient_phone { get => recipient_phone; set => recipient_phone = value; }
        public DateTime Delivery_time { get => delivery_time; set => delivery_time = value; }
    }
}
