using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Flower.DAL.Interfaces;

namespace Flower.Areas.Manager.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IViewOrderService _orderService;

        public OrdersController(IViewOrderService orderService)
        {
            _orderService = orderService;
        }

        

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetOrdersByUserId(int userId)
        {
            var orders = await _orderService.GetUserOrdersAsync(userId);

            if (orders == null || !orders.Any())
            {
                return NotFound(new { Message = "No orders found for the given user." });
            }

            return Ok(orders);
        }
    }
}