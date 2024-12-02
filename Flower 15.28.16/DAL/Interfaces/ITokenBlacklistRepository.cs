namespace Flower.DAL.Interfaces
{
    public interface ITokenBlacklistRepository
    {
        Task AddTokenToBlacklistAsync(string token, DateTime expiration);
        Task<bool> IsTokenBlacklistedAsync(string token);
    }
}
