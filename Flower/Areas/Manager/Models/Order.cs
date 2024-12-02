using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flower.DAL;
using Flower.Areas;
using Flower.Areas.Auther.Models;

namespace Flower.Areas.Manager.Models
{
    public class Order
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


    }
}