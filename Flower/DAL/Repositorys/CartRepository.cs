using Flower.Areas.Dtos;
using Flower.DAL.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Flower.DAL.Repositorys
{
    public class CartRepository : ICartRepository
    {
        private readonly FlowerDbContext _context;

        public CartRepository(FlowerDbContext context)
        {
            _context = context;
        }

        public async Task AddToCart(
        int? userId,
        Guid? sessionId,
        int flowerId,
        int quantity,
        decimal price,
        string? message,
        string recipientName,
        string recipientAddress,
        string recipientPhone)
        {
            var sql = "EXEC AddToCart @UserId, @SessionId, @FlowerId, @Quantity, @Price, @Message, @RecipientName, @RecipientAddress, @RecipientPhone";

            await _context.Database.ExecuteSqlRawAsync(sql,
                new[]
                {
                new SqlParameter("@UserId", userId ?? (object)DBNull.Value),
                new SqlParameter("@SessionId", sessionId ?? (object)DBNull.Value),
                new SqlParameter("@FlowerId", flowerId),
                new SqlParameter("@Quantity", quantity),
                new SqlParameter("@Price", price),
                new SqlParameter("@Message", message ?? (object)DBNull.Value),
                new SqlParameter("@RecipientName", recipientName),
                new SqlParameter("@RecipientAddress", recipientAddress),
                new SqlParameter("@RecipientPhone", recipientPhone)
                });
        }

        public async Task DeleteCartItem(int cartItemId)
        {
            var sql = "EXEC DeleteCartItem @CartItemId";
            await _context.Database.ExecuteSqlRawAsync(sql, new SqlParameter("@CartItemId", cartItemId));
        }


        public async Task<List<CartItemDto>> GetCartItems(int? userId, Guid? sessionId)
        {
            var userIdParam = new SqlParameter("@UserId", userId ?? (object)DBNull.Value);
            var sessionIdParam = new SqlParameter("@SessionId", sessionId ?? (object)DBNull.Value);

            var cartItems =  await _context.cartItemDtos
                .FromSqlRaw("EXEC dbo.GetCartItems @UserId , @SessionId", userIdParam, sessionIdParam)
                .ToListAsync();
            Console.WriteLine(cartItems);
            return cartItems;
        }

        public async Task UpdateCartAsync(int cartId, List<CartItemDto> cartItems)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    foreach (var item in cartItems)
                    {
                        var parameters = new[]
                        {
                    new SqlParameter("@CartId", cartId),
                    new SqlParameter("@FlowerId", item.Flower_Id),
                    new SqlParameter("@Quantity", item.Quantity),
                    new SqlParameter("@Price", item.Price),
                    new SqlParameter("@Message", item.Message ?? (object)DBNull.Value),
                    new SqlParameter("@RecipientName", item.Recipient_Name ?? (object)DBNull.Value),
                    new SqlParameter("@RecipientAddress", item.Recipient_Address ?? (object)DBNull.Value),
                    new SqlParameter("@RecipientPhone", item.Recipient_Phone ?? (object)DBNull.Value),
                    new SqlParameter("@DeliveryTime", item.Delivery_time ?? (object)DBNull.Value)
                };

                        // Gọi stored procedure UpdateCart cho từng item
                        await _context.Database.ExecuteSqlRawAsync("EXEC UpdateCart @CartId, @FlowerId, @Quantity, @Price, @Message, @RecipientName, @RecipientAddress, @RecipientPhone, @DeliveryTime", parameters);
                    }

                    // Commit transaction nếu mọi thứ thành công
                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    // Rollback transaction nếu có lỗi
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

    }
}
