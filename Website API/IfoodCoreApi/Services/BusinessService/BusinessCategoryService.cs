using IfoodCoreApi.Infra.Repository.Business;
using IfoodCoreApi.Models.Business;

namespace IfoodCoreApi.Services.BusinessService
{
    public class BusinessCategoryService : IServiceBasicOperations<BusinessCategory>
    {
        private readonly BusinessCategoryRepository repository;

        public BusinessCategoryService(BusinessCategoryRepository repository)
        {
            this.repository = repository;
        }

        public Task DeleteById(int id)
        {
            return repository.DeleteById(id);
        }

        public Task ExistById(int id)
        {
            return repository.ExistById(id);
        }

        public Task<IEnumerable<BusinessCategory>> GetAll()
        {
            return repository.GetAll();
        }

        public Task<BusinessCategory> GetById(int id)
        {
            return repository.GetById(id);
        }

        public Task Post(BusinessCategory entity)
        {
            return repository.Post(entity);
        }

        public Task Put(int id, BusinessCategory entity)
        {
            return repository.Put(id, entity);
        }
    }
}
