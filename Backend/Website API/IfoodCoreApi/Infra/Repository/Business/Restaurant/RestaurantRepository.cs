using IfoodCoreApi.Infra.Context;
using IfoodCoreApi.Models.Business;
using IfoodCoreApi.Models.Business.Restaurants;
using Microsoft.EntityFrameworkCore;

namespace IfoodCoreApi.Infra.Repository.Business
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly AppDbContext _context;

        public RestaurantRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task DeleteById(int id)
        {
            Restaurant? restaurant = await GetById(id);
            if (restaurant != null)
            {
                _context.RestaurantContext.Remove(restaurant);
                _context.Entry(restaurant).State = EntityState.Deleted;
                await Save();
            }
        }

        public async Task<bool> ExistById(int id)
        {
            try
            {
                bool result = await _context.RestaurantContext.AsNoTrackingWithIdentityResolution().AnyAsync(x => x.Id == id);
                return result;
            }
            catch (Exception)
            {
                //TODO add logger msg
                return false;
            }
        }

        public async Task<IEnumerable<Restaurant>> GetAll()
        {
            return await _context.RestaurantContext.AsNoTrackingWithIdentityResolution().ToListAsync();
        }

        public async Task<IEnumerable<Restaurant>> GetAllByServiceAvgValue(int avgValue)
        {
            return await _context.RestaurantContext.AsNoTrackingWithIdentityResolution().Where(x => x.Id_ServiceAvgValue == avgValue).ToListAsync();
        }

        public async Task<IEnumerable<Restaurant>> GetByCategory(int category)
        {
            return await _context.RestaurantContext.AsNoTrackingWithIdentityResolution().Where(x => x.Id_Category == category).ToListAsync();
        }

        public async Task<Restaurant?> GetById(int id)
        {
            return await _context.RestaurantContext.AsNoTrackingWithIdentityResolution().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Restaurant?> GetByName(string name)
        {
            return await _context.RestaurantContext.AsNoTrackingWithIdentityResolution().FirstOrDefaultAsync(x => x.Name.Equals(name));
        }

        public async Task<IEnumerable<Restaurant>> GetByParcialName(string parcialName)
        {
            return await _context.RestaurantContext.AsNoTrackingWithIdentityResolution().Where(x => x.Name.Contains(parcialName)).ToListAsync();
        }

        public async Task Post(Restaurant entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            await _context.RestaurantContext.AddAsync(entity);
            await Save();
        }

        public async Task Put(int id, Restaurant entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await Save();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
