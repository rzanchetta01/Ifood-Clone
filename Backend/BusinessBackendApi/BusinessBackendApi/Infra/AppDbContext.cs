using BusinessBackendApi.Model;
using Microsoft.EntityFrameworkCore;

namespace BusinessBackendApi.Infra
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Restaurant> Restaurants { get; protected set; }

        public DbSet<Product> Products { get; protected set; }
    }
}
