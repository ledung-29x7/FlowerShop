    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Flower.Areas.Dtos
    {
        public class ViewOrderDto
    {
        
        public int OrderId { get; set; }

        
        public decimal TotalAmount { get; set; }

        
        public string PaymentStatus { get; set; }

        
        public string PaymentMethod { get; set; }

        
        public string RecipientName { get; set; }

        
        public string RecipientAddress { get; set; }

        
        public string RecipientPhone { get; set; }

        
        public DateTime DeliveryTime { get; set; }


        public bool IsCancelled { get; set; }

        
        public DateTime CreatedAt { get; set; }


        public string StoreName { get; set; }

        
        public string StoreAddress { get; set; }

        
        public string StorePhone { get; set; }

        
        public string StoreEmail { get; set; }

        
        public List<ViewOrderItemDto> OrderItems { get; set; }
    }
    }