using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flower.Areas.Dtos
{
    public class ViewOrderItemDto
    {
        
        public int FlowerId { get; set; }

        
        public string FlowerName { get; set; }

        
        public int Quantity { get; set; }

        
        public decimal UnitPrice { get; set; }

        
        public decimal TotalPrice => Quantity * UnitPrice;
    }
}