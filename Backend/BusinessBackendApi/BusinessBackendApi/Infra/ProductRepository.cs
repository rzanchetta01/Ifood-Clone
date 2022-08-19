using BusinessBackendApi.Infra.Interfaces;
using BusinessBackendApi.Model;
using Microsoft.EntityFrameworkCore;

namespace BusinessBackendApi.Infra
{
    public class ProductRepository : IProductRepository<Product>
    {
        private readonly AppDbContext context;

        public ProductRepository(AppDbContext context)
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
            return await context.Products.AsNoTrackingWithIdentityResolution().AnyAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await context.Products.AsNoTrackingWithIdentityResolution().ToListAsync();
        }

        public async Task<Product?> GetById(int id)
        {
            return await context.Products.AsNoTrackingWithIdentityResolution().FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Save(Product entity)
        {
            context.Entry(entity).State = EntityState.Added;
            context.Products.Add(entity);
            context.SaveChanges();
        }

        public void Update(Product entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
