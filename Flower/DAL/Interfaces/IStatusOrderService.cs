using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flower.Areas.Dtos;

namespace Flower.DAL.Interfaces
{
    public interface IStatusOrderService
    {
        Task<OrderStatusDto> GetOrderStatusByIdAsync(int orderId);
    }
}