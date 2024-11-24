namespace Flower.DAL.Interfaces
{
    public interface ICartService
    {
        Task AddItemToCartAsync(int userId, int flowerId, int quantity, string message);

    }
}
