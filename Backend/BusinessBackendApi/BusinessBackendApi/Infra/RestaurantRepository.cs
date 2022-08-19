using BusinessBackendApi.Infra.Interfaces;
using BusinessBackendApi.Model;
using Microsoft.EntityFrameworkCore;

namespace BusinessBackendApi.Infra
{
    public class RestaurantRepository : IRestaurantRepository<Restaurant>
    {
        private readonly AppDbContext context;

        public RestaurantRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void DeleteById(int id)
        {
            var obj = GetById(id);
            context.Entry(obj).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public async Task<bool> Exist(int id)
        {
            return await context.Restaurants.AsNoTrackingWithIdentityResolution().AnyAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Restaurant>> GetAll()
        {
            return await context.Restaurants.AsNoTrackingWithIdentityResolution().ToListAsync();
        }

        public async Task<Restaurant?> GetById(int id)
        {
            return await context.Restaurants.AsNoTrackingWithIdentityResolution().FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Save(Restaurant entity)
        {
            context.Entry(entity).State = EntityState.Added;
            context.Restaurants.Add(entity);
            context.SaveChanges();
        }

        public void Update(Restaurant entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
