using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flower.Areas.Dtos
{
    public class ViewOrderItemDto
    {
        // ID của hoa
        public int FlowerId { get; set; }

        // Tên của hoa
        public string FlowerName { get; set; }

        // Số lượng
        public int Quantity { get; set; }

        // Đơn giá
        public decimal UnitPrice { get; set; }

        // Tổng giá trị (tính toán động, không cần lưu trữ)
        public decimal TotalPrice => Quantity * UnitPrice;
    }
}