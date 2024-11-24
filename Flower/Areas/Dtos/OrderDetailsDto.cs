namespace Flower.Areas.Dtos
{
    public class OrderDetailsDto
    {
        public int order_id { get; set; }
        public int user_id { get; set; }
        public int store_id { get; set; }
        public decimal total_amount { get; set; }
        public string payment_status { get; set; }
        public string payment_method { get; set; }
        public string recipient_name { get; set; }
        public string recipient_address { get; set; }
        public string recipient_phone { get; set; }
        public DateTime delivery_time { get; set; }
        public DateTime created_at { get; set; }
        public bool is_cancelled { get; set; }
        public List<OrderItemDetailsDto> OrderItem { get; set; }
    }
}
