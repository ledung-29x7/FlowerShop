//using Flower.Areas.User.Models;
//using Flower.DAL.Interfaces;
//using Microsoft.AspNetCore.Mvc;

//namespace Flower.Areas.User.controllers
//{
//    public class AddItemToCartController
//    {
//        [ApiController]
//        [Route("api/cart")]
//        public class CartController : ControllerBase
//        {
//            private readonly ICartService _cartService;
//            private readonly ICartRepository _cartRepository;

//            public CartController(ICartService cartService, ICartRepository cartRepository)
//            {
//                _cartService = cartService;
//                _cartRepository = cartRepository;
//            }

//            [HttpPost("/{add-Item}")]
//            public async Task<IActionResult> AddItemToCart([FromBody] AddItemToCartRequest request)
//            {
//                try
//                {
//                    await _cartService.AddItemToCartAsync(request.UserId, request.FlowerId, request.Quantity, request.Message);
//                    return Ok(new { message = "Item added to cart successfully!" });
//                }
//                catch (Exception ex)
//                {
//                    return BadRequest(new { error = ex.Message });
//                }
//            }
//        }
//    }
//}
