namespace Flower.DAL.Interfaces
{
    public interface ICartRepository
    {
        Task AddItemToCartAsync(int userId, int flowerId, int quantity, string message);
    }
}
