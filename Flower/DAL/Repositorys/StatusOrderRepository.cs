using System;
using System.Data;
using System.Threading.Tasks;
using Flower.Areas.Dtos;
using Flower.DAL.Interfaces;
using Microsoft.Data.SqlClient;

namespace Flower.DAL.Repositorys
{
    public class StatusOrderRepository : IStatusOrderRepository
    {
        private readonly string _connectionString;

        public StatusOrderRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Flower");
        }

        public async Task<string> GetOrderStatusByIdAsync(int orderId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var command = new SqlCommand("dbo.GetOrderStatusById", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@OrderId", orderId);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return reader["Status"].ToString();
                    }
                    else
                    {
                        throw new KeyNotFoundException($"Order with ID {orderId} not found.");
                    }
                }
            }
        }
    }

}
