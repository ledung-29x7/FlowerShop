using Flower.Areas.Admin.Models;
using Flower.Areas.Auther.Models;
using Flower.Areas.Dtos;
using Flower.Areas.Manager.Models;
using Flower.Areas.User.Models;
using Microsoft.EntityFrameworkCore;

namespace Flower
{
    public class FlowerDbContext : DbContext
    {
        public FlowerDbContext() { }

        public FlowerDbContext(DbContextOptions<FlowerDbContext> options): base(options) { }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FlowerWithImagesDto>().HasNoKey();
            modelBuilder.Entity<Cart>().HasNoKey();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> users { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Occasion> occasions { get; set; }
        public DbSet<Flowers> flowers { get; set; }
        public DbSet<Image> images { get; set; }
        public DbSet<Store> stores { get; set; }
        public DbSet<FlowerWithImagesDto> flowerWithImagesDtos { get; set; }
        public DbSet<Cart> carts { get; set; }
        public DbSet<Cart_Items> Cart_Items { get; set; }
        public DbSet<Message> messages { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Order_Items> order_items { get; set; }
        public DbSet<SalesReport> salesReports { get; set; }
        public DbSet<StoreFlower> storeFlowers { get; set; }
        public DbSet<Notification> notifications { get; set; }
        public DbSet<UserStore> userStores { get; set; }
        
    }
}
