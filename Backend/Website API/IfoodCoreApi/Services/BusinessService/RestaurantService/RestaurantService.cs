using IfoodCoreApi.Infra.Repository.Business;
using IfoodCoreApi.Models.Business;
using IfoodCoreApi.Models.Business.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfoodCoreApi.Services.BusinessService.RestaurantService
{
    public class RestaurantService : BaseService<Restaurant>, IRestaurantService
    {
        private readonly RestaurantRepository repository;

        public RestaurantService(RestaurantRepository repository)
        { 
            this.repository = repository;
        }

        public Task<IEnumerable<Restaurant>> GetAllByServiceAvgValue(int avgValue)
        {
            return repository.GetAllByServiceAvgValue(avgValue);
        }

        public Task<Restaurant> GetByName(string name)
        {
            return repository.GetByName(name);
        }

        public Task<IEnumerable<Restaurant>> GetByParcialName(string parcialName)
        {
            return repository.GetByParcialName(parcialName);
        }

        public Task<IEnumerable<Restaurant>> GetByCategory(int category)
        {
            return repository.GetByCategory(category);
        }

        public Task<Restaurant> GetById(int id)
        {
            return repository.GetById(id);
        }

        public Task<IEnumerable<Restaurant>> GetAll()
        {
            return repository.GetAll();
        }

        public Task DeleteById(int id)
        { 
            return repository.DeleteById(id);
        }

        public Task ExistById(int id)
        {
            return repository.ExistById(id);
        }

        public Task Post(Restaurant entity)
        {
            return repository.Post(entity);
        }

        public Task Put(int id, Restaurant entity)
        {
            return repository.Put(id, entity);
        }
    }
}
