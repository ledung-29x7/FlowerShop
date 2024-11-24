namespace Flower.Areas.User.Models
{
    public class AddItemToCartRequest
    {
        public int UserId { get; set; }
        public int FlowerId { get; set; }
        public int Quantity { get; set; }
        public string Message { get; set; }
    }
}
