using IfoodCoreApi.Models.Business;

namespace IfoodCoreApi.Infra.Repository.Business
{
    public interface IBaseRepository<TEntity> : Repository.IBaseRepository<TEntity> where TEntity : BaseBusiness
    {
        Task<IEnumerable<TEntity>> GetAllByServiceAvgValue(int avgValue);
        Task<IEnumerable<TEntity>> GetByParcialName(string parcialName);
        Task<IEnumerable<TEntity>> GetByCategory(int category);
        Task<TEntity> GetByName(string name);
    }
}
