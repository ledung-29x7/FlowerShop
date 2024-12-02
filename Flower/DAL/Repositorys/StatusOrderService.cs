using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flower.Areas.Dtos;
using Flower.DAL.Interfaces;

namespace Flower.DAL.Repositorys
{
    public class StatusOrderService : IStatusOrderService
    {
        private readonly IStatusOrderRepository _repository;

        public StatusOrderService(IStatusOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<OrderStatusDto> GetOrderStatusByIdAsync(int orderId)
        {
            var status = await _repository.GetOrderStatusByIdAsync(orderId);

            return new OrderStatusDto
            {
                OrderId = orderId,
                Status = status
            };
        }
    }
}