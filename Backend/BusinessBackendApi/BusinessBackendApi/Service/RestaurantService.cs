using BusinessBackendApi.Infra;
using BusinessBackendApi.Model;
using BusinessBackendApi.Service.Interfaces;

namespace BusinessBackendApi.Service
{
    public class RestaurantService : IBaseService<Restaurant>
    {
        private readonly RestaurantRepository repository;

        public RestaurantService(RestaurantRepository repository)
        {
            this.repository = repository;
        }

        public void DeleteById(int id)
        {
            repository.DeleteById(id);
        }

        public Task<IEnumerable<Restaurant>> GetAll()
        {
            return repository.GetAll();
        }

        public Task<Restaurant?> GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Post(Restaurant entity)
        {
            repository.Save(entity);
        }

        public void Update(int id, Restaurant entity)
        {
            repository.Update(entity);
        }
    }
}
