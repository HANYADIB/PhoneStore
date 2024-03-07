using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PhoneStore.Models
{
    public class ApplicationDb:IdentityDbContext<ApplacationUser>
    {
        public ApplicationDb() : base()
        {

        }
        public ApplicationDb(DbContextOptions<ApplicationDb> options) : base(options)
        {
        }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CountryUser> CountryUsers { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CityUser> CityUsers { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<OrderStatus> orderStatuses { get; set; }

    }
}
