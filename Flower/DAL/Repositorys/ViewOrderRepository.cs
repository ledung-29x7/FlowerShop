using Flower.Areas.Dtos;
using Flower.Areas.Manager.Models;
using Flower.DAL.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Flower.DAL.Repositorys
{
    public class ViewOrderRepository : IViewOrderRepository
    {
        private readonly FlowerDbContext _context;
        private readonly string _connectionString;
        public ViewOrderRepository(FlowerDbContext context, IConfiguration configuration)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("Flower");
        }
        public async Task<List<ViewOrderDto>> GetOrdersByUserIdAsync(int userId)
        {
            var orders = new List<ViewOrderDto>();
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("dbo.GetOrdersByUserId", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int) { Value = userId });

                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var order = new ViewOrderDto
                            {
                                OrderId = reader.GetInt32(reader.GetOrdinal("order_id")),
                                TotalAmount = reader.GetDecimal(reader.GetOrdinal("total_amount")),
                                PaymentStatus = reader.GetString(reader.GetOrdinal("payment_status")),
                                PaymentMethod = reader.GetString(reader.GetOrdinal("payment_method")),
                                RecipientName = reader.GetString(reader.GetOrdinal("recipient_name")),
                                RecipientAddress = reader.GetString(reader.GetOrdinal("recipient_address")),
                                RecipientPhone = reader.GetString(reader.GetOrdinal("recipient_phone")),
                                DeliveryTime = reader.GetDateTime(reader.GetOrdinal("delivery_time")),
                                IsCancelled = reader.GetBoolean(reader.GetOrdinal("is_cancelled")),
                                CreatedAt = reader.GetDateTime(reader.GetOrdinal("created_at")),
                                StoreName = reader.IsDBNull(reader.GetOrdinal("store_name")) ? null : reader.GetString(reader.GetOrdinal("store_name")),
                                StoreAddress = reader.IsDBNull(reader.GetOrdinal("store_address")) ? null : reader.GetString(reader.GetOrdinal("store_address")),
                                StorePhone = reader.IsDBNull(reader.GetOrdinal("store_phone")) ? null : reader.GetString(reader.GetOrdinal("store_phone")),
                                StoreEmail = reader.IsDBNull(reader.GetOrdinal("store_email")) ? null : reader.GetString(reader.GetOrdinal("store_email"))
                            };

                            orders.Add(order);
                        }
                    }
                }
            }

            return orders;
        }
    }
}
