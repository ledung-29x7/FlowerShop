using Flower.Areas.Dtos;

namespace Flower.DAL.Interfaces
{
    public interface IViewOrderRepository
{
    Task<List<ViewOrderDto>> GetOrdersByUserIdAsync(int userId);
}

}