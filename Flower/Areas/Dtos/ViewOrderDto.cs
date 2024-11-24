    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Flower.Areas.Dtos
    {
        public class ViewOrderDto
    {
        // ID đơn hàng
        public int OrderId { get; set; }

        // Tổng tiền của đơn hàng
        public decimal TotalAmount { get; set; }

        // Trạng thái thanh toán (ví dụ: Paid, Pending, etc.)
        public string PaymentStatus { get; set; }

        // Phương thức thanh toán (Credit Card, Cash, etc.)
        public string PaymentMethod { get; set; }

        // Tên người nhận
        public string RecipientName { get; set; }

        // Địa chỉ người nhận
        public string RecipientAddress { get; set; }

        // Số điện thoại người nhận
        public string RecipientPhone { get; set; }

        // Thời gian giao hàng
        public DateTime DeliveryTime { get; set; }

        // Trạng thái hủy đơn (true nếu đơn hàng bị hủy)
        public bool IsCancelled { get; set; }

        // Thời gian tạo đơn hàng
        public DateTime CreatedAt { get; set; }

        // Tên cửa hàng (nếu có)
        public string StoreName { get; set; }

        // Địa chỉ cửa hàng (nếu có)
        public string StoreAddress { get; set; }

        // Số điện thoại cửa hàng (nếu có)
        public string StorePhone { get; set; }

        // Email cửa hàng (nếu có)
        public string StoreEmail { get; set; }

        // Danh sách các sản phẩm trong đơn hàng
        public List<ViewOrderItemDto> OrderItems { get; set; }
    }
    }