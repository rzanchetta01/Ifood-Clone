using IfoodCoreApi.Infra.Context;
using IfoodCoreApi.Models.Business;
using Microsoft.EntityFrameworkCore;

namespace IfoodCoreApi.Infra.Repository.Business
{
    public class BusinessCategoryRepository : Repository.IBaseRepository<BusinessCategory>
    {
        private readonly AppDbContext _context;

        public BusinessCategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task DeleteById(int id)
        {
            var category = await GetById(id);

            if(category is not null)
            {
                _context.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _context.BusinessCategories.Remove(category);
                await Save();
            }
        }

        public async Task<bool> ExistById(int id)
        {
            try
            {
                return await _context.BusinessCategories.AsNoTrackingWithIdentityResolution().AnyAsync(x => x.Id == id);
            }
            catch (Exception)
            {
                //TODO ADD LOGGER
                return false;
            }
        }

        public async Task<IEnumerable<BusinessCategory>> GetAll()
        {
            return await _context.BusinessCategories.AsNoTrackingWithIdentityResolution().ToListAsync();
        }

        public async Task<BusinessCategory?> GetById(int id)
        {
            return await _context.BusinessCategories.AsNoTrackingWithIdentityResolution().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Post(BusinessCategory entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.BusinessCategories.AddAsync(entity);
            await Save();
        }

        public async Task Put(int id, BusinessCategory entity)
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
