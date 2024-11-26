using Flower.Areas.Dtos;

namespace Flower.DAL.Interfaces
{
    public interface ICartRepository
    {
        Task AddToCart(
        int? userId,
        Guid? sessionId,
        int flowerId,
        int quantity,
        decimal price,
        string? message,
        string recipientName,
        string recipientAddress,
        string recipientPhone
        );
        Task<List<CartItemDto>> GetCartItems(int? userId, Guid? sessionId);
        Task UpdateCartAsync(int cartId, List<CartItemDto> cartItems);
        Task DeleteCartItem(int cartItemId);
    }

}
