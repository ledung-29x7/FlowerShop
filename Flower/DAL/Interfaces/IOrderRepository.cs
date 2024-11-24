using Flower.Areas.Dtos;

namespace Flower.DAL.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<OrderDetailsDto>> GetOrderDetailsAsync(int orderId);
    }

}
