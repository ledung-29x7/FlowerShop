using Flower.Areas.Admin.Models;
using Flower.Areas.Auther.Models;
using Flower.Areas.Manager.Models;
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
            base.OnModelCreating(modelBuilder);
            
        }

        public DbSet<User> users { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Occasion> occasions { get; set; }
        public DbSet<Flowers> flowers { get; set; }
        public DbSet<Image> images { get; set; }
    }
}
