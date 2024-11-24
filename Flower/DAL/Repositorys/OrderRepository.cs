using Flower.Areas.Dtos;
using Flower.DAL.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Flower.DAL.Repositorys
{
    public class OrderRepository : IOrderRepository
    {
        private readonly FlowerDbContext _context;

        public OrderRepository(FlowerDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrderDetailsDto>> GetOrderDetailsAsync(int order_id)
        {
            var id_Param = new SqlParameter("@order_id", order_id);
            var orderDetails = await _context.OrderDetails
                .FromSqlRaw("EXECUTE dbo.GetOrderDetails @order_id", id_Param)
                .ToListAsync();
            return orderDetails.ToList();
        }

    }
}
