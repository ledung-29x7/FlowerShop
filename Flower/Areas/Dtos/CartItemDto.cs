namespace Flower.Areas.Dtos
{
    public class CartItemDto
    {
        public int Cart_Id { get; set; }
        public int? Cart_Item_Id { get; set; } 
        public int? Flower_Id { get; set; } 
        public string? Flower_Name { get; set; }
        public int? Quantity { get; set; } 
        public decimal? Price { get; set; } 
        public string? Message { get; set; }  
        public string? Recipient_Name { get; set; } 
        public string? Recipient_Address { get; set; } 
        public string? Recipient_Phone { get; set; }   
        public DateTime? Delivery_time { get; set; }
    }
}
