namespace Flower.Areas.Users.Models
{
    public class Cart_Items
    {
        private int cart_item_id;
        private int cart_id;
        private int flower_id;
        private int quantity;
        private DateTime added_at;
        private decimal price;
        private string message;
        private string recipient_name;
        private string recipient_address;
        private string recipient_phone;
        private DateTime delivery_time;

        public int Cart_item_id { get => cart_item_id; set => cart_item_id = value; }
        public int Cart_id { get => cart_id; set => cart_id = value; }
        public int Flower_id { get => flower_id; set => flower_id = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public DateTime Added_at { get => added_at; set => added_at = value; }
        public decimal Price { get => price; set => price = value; }
        public string Message { get => message; set => message = value; }
        public string Recipient_name { get => recipient_name; set => recipient_name = value; }
        public string Recipient_address { get => recipient_address; set => recipient_address = value; }
        public string Recipient_phone { get => recipient_phone; set => recipient_phone = value; }
        public DateTime Delivery_time { get => delivery_time; set => delivery_time = value; }
    }
}
