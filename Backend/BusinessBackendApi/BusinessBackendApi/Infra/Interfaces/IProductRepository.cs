using BusinessBackendApi.Model;

namespace BusinessBackendApi.Infra.Interfaces
{
    public interface IProductRepository<TEntity> : IBaseCrud<TEntity> where TEntity : Product
    {
    }
}
