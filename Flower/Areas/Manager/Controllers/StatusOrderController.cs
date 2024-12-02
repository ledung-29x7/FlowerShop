using System.Threading.Tasks;
using Flower.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Flower.Areas.Manager.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class StatusOrderController : ControllerBase
    {
        private readonly IStatusOrderService _service;

        public StatusOrderController(IStatusOrderService service)
        {
            _service = service;
        }

        [HttpGet("{orderId}/status")]
        public async Task<IActionResult> GetOrderStatus(int orderId)
        {
            var status = await _service.GetOrderStatusByIdAsync(orderId);

            if (status == null)
            {
                return NotFound(new { Message = "Order not found." });
            }

            return Ok(status);
        }
    }
}
