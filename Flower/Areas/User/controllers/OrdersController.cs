using AutoMapper;
using Flower.Areas.Auther.Models;
using Flower.Areas.Dtos;
using Flower.Areas.Manager.Models;
using Flower.Areas.User.Models;
using Flower.DAL.Interfaces;
using Flower.DAL.Repositorys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Flower.Areas.User.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICartService _cartService;
        private readonly ICartRepository _cartRepository;

        public OrdersController(IOrderRepository orderRepository,ICartRepository cartRepository,ICartService cartService)
        {
            _orderRepository = orderRepository;
            _cartService = cartService;
            _cartRepository = cartRepository;
        }

        [HttpGet("/{order_id}")]
        public async Task<IActionResult> GetOrderDetails(int order_id)
        {
            try
            {
                var orderDetails = await _orderRepository.GetOrderDetailsAsync(order_id);
                return Ok(orderDetails);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred.", Details = ex.Message });
            }
        }
        [HttpPost("/{add-Item}")]
        public async Task<IActionResult> AddItemToCart([FromBody] AddItemToCartRequest request)
        {
            try
            {
                await _cartService.AddItemToCartAsync(request.UserId, request.FlowerId, request.Quantity, request.Message);
                return Ok(new { message = "Item added to cart successfully!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }


}
