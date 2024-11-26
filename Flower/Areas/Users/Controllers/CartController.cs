using Flower.Areas.Dtos;
using Flower.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Flower.Areas.Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;
        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        [HttpPost("add-multiple")]
        public async Task<IActionResult> AddMultipleToCart(AddMultipleToCartDto dto)
        {
            var userId = User.Identity?.IsAuthenticated == true
                ? int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value)
                : (int?)null;

            var sessionId = userId == null ? Guid.NewGuid() : (Guid?)null;

            foreach (var item in dto.Items)
            {
                await _cartRepository.AddToCart(userId,
                                                sessionId,
                                                item.FlowerId,
                                                item.Quantity,
                                                item.Price,
                                                item.Message,
                                                item.RecipientName,
                                                item.RecipientAddress,
                                                item.RecipientPhone);
            }

            return Ok("Đã thêm nhiều sản phẩm vào giỏ hàng!");
        }

        [HttpGet]
        public async Task<IActionResult> GetCartItems()
        {
            var userId = User.Identity?.IsAuthenticated == true
                        ? int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value)
                        : (int?)null;

            // Lấy hoặc tạo mới sessionId
            var sessionId = HttpContext.Session.GetString("SessionId");
            if (string.IsNullOrEmpty(sessionId))
            {
                sessionId = Guid.NewGuid().ToString();
                HttpContext.Session.SetString("SessionId", sessionId);
            }

            var parsedSessionId = Guid.Parse(sessionId);

            var cartItems = await _cartRepository.GetCartItems(userId, parsedSessionId);
            return Ok(cartItems);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateCart([FromBody] List<CartItemDto> cartItems)
        {
            if (cartItems == null || cartItems.Count == 0)
            {
                return BadRequest("Cart items cannot be null or empty.");
            }

            var cartId = cartItems[0].Cart_Id; // Giả sử tất cả các mặt hàng đều thuộc cùng một giỏ hàng
            foreach (var item in cartItems)
            {
                if (item.Cart_Id != cartId)
                {
                    return BadRequest("All items must belong to the same cart.");
                }
            }

            // Cập nhật giỏ hàng với các sản phẩm trong danh sách
            await _cartRepository.UpdateCartAsync(cartId, cartItems);
            return Ok("Cart updated successfully.");
        }


        [HttpDelete("remove/{cartItemId}")]
        public async Task<IActionResult> RemoveFromCart(int cartItemId)
        {
            await _cartRepository.DeleteCartItem(cartItemId);
            return Ok("Item removed from cart.");
        }

    }

}
