using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flower.Areas.Dtos
{
    public class CheckoutResponse
    {
        public int OrderId { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentStatus { get; set; }
        public string Message { get; set; }
    }
}