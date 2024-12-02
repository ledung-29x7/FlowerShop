using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flower.Areas.Dtos;

namespace Flower.DAL.Interfaces
{
    public interface IStatusOrderRepository
    {
        Task<string> GetOrderStatusByIdAsync(int orderId);
    }
}