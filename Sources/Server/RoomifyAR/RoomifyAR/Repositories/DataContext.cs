using Microsoft.EntityFrameworkCore;
using RoomifyAR.Entities;

namespace RoomifyAR.Repositories
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
            
        }

        public DbSet<User> Users { get; set; }  
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductMedia> ProductMedias { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Wishlist> Wishlist { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // add more Constraint here
            base.OnModelCreating(modelBuilder);
        }
    }
}
