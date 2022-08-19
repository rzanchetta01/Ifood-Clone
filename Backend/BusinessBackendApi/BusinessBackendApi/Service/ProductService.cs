using BusinessBackendApi.Infra;
using BusinessBackendApi.Model;
using BusinessBackendApi.Service.Interfaces;

namespace BusinessBackendApi.Service
{
    public class ProductService : IBaseService<Product>
    {
        private readonly ProductRepository product;

        public ProductService(ProductRepository product)
        {
            this.product = product;
        }

        public void DeleteById(int id)
        {
            product.DeleteById(id);
        }

        public Task<IEnumerable<Product>> GetAll()
        {
            return product.GetAll();
        }

        public Task<Product?> GetById(int id)
        {
            return product.GetById(id);
        }

        public void Post(Product entity)
        {
            product.Save(entity);
        }

        public void Update(int id, Product entity)
        {
            product.Update(entity);
        }
    }
}
