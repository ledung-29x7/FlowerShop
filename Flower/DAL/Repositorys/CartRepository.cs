using Flower.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;


namespace Flower.DAL.Repositorys
{
    public class CartRepository :ICartRepository
    {
        private readonly FlowerDbContext _context;

        public CartRepository(FlowerDbContext context)
        {
            _context = context;
        }


        public async Task AddItemToCartAsync(int userId, int flowerId, int quantity, string message)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC AddItemToCart @UserId = {0}, @FlowerId = {1}, @Quantity = {2}, @Message = {3}",
                userId, flowerId, quantity, message
            );
        }
    }
}
