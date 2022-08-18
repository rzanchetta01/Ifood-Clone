using IfoodCoreApi.Models.Business;
using IfoodCoreApi.Models.Business.Restaurants;
using Microsoft.EntityFrameworkCore;

namespace IfoodCoreApi.Infra.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Restaurant> RestaurantContext { get; set; }
        public DbSet<BusinessCategory> BusinessCategories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, false)
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("db"));
        }

        internal Task<bool> AsNoTracking()
        {
            throw new NotImplementedException();
        }
    }
}
