using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flower.Areas.Dtos
{
    public class CheckoutRequest
    {
        public int UserId { get; set; }
        public int StoreId { get; set; }
        public string PaymentMethod { get; set; }
        public string RecipientName { get; set; }
        public string RecipientAddress { get; set; }
        public string RecipientPhone { get; set; }
        public DateTime DeliveryTime { get; set; }
    }
}