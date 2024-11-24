using Flower.DAL.Interfaces;

namespace Flower.DAL.Repositorys
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task AddItemToCartAsync(int userId, int flowerId, int quantity, string message)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than zero.");
            }

            await _cartRepository.AddItemToCartAsync(userId, flowerId, quantity, message);
        }
    }
}
