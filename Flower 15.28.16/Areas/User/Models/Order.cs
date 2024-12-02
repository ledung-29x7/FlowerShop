namespace Flower.Areas.User.Models
{
    public class Order
    {
        private int order_id;
        private int user_id;
        private int store_id;
        private decimal total_amount;
        private string payment_status;
        private string payment_method;
        private string recipient_name;
        private string recipient_address;
        private string recipient_phone;
        private DateTime delivery_time;
        private DateTime created_at;
        private bool is_cancelled;

        public int Order_id { get => order_id; set => order_id = value; }
        public int User_id { get => user_id; set => user_id = value; }
        public int Store_id { get => store_id; set => store_id = value; }
        public decimal Total_amount { get => total_amount; set => total_amount = value; }
        public string Payment_status { get => payment_status; set => payment_status = value; }
        public string Payment_method { get => payment_method; set => payment_method = value; }
        public string Recipient_name { get => recipient_name; set => recipient_name = value; }
        public string Recipient_address { get => recipient_address; set => recipient_address = value; }
        public string Recipient_phone { get => recipient_phone; set => recipient_phone = value; }
        public DateTime Delivery_time { get => delivery_time; set => delivery_time = value; }
        public DateTime Created_at { get => created_at; set => created_at = value; }
        public bool Is_cancelled { get => is_cancelled; set => is_cancelled = value; }
    }
}
