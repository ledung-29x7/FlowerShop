namespace Flower.Areas.Dtos
{
    public class OrderItemDetailsDto
    {
        public int flower_id { get; set; }
        public string? flower_name { set; get; }
        public int quantity { get; set; }
        public decimal unit_price { get; set; }
        public decimal total_price { get; set; }
    }
}
