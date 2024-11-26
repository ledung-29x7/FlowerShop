namespace Flower.Areas.Dtos
{
    public class AddToCartDto
    {
        public int FlowerId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string? Message { get; set; }
        public string RecipientName { get; set; }
        public string RecipientAddress { get; set; }
        public string RecipientPhone { get; set; }
    }
}
