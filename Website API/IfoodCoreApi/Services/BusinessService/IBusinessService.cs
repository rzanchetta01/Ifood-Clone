using IfoodCoreApi.Models.Business;

namespace IfoodCoreApi.Services.BusinessService
{
    public interface IBusinessService<TEntity> : IServiceBasicOperations<TEntity> where TEntity : BaseBusiness
    {
        Task<IEnumerable<TEntity>> GetAllByServiceAvgValue(int avgValue);

        Task<IEnumerable<TEntity>> GetByParcialName(string parcialName);
    }
}
