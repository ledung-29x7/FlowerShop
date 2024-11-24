using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flower.Areas.Dtos;
using Flower.DAL.Interfaces;
using Flower.DAL.Repositorys;

namespace Flower.DAL.Repositorys
{
    public class ViewOrderService : IViewOrderService
{
    private readonly IViewOrderRepository _orderRepository;

    public ViewOrderService(IViewOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<List<ViewOrderDto>> GetUserOrdersAsync(int userId)
    {
        return await _orderRepository.GetOrdersByUserIdAsync(userId);
    }
}


    
}