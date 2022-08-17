using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfoodCoreApi.Infra.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task DeleteById(int id);
        Task Post(TEntity entity);
        Task Put(int id, TEntity entity);
        Task<bool> ExistById(int id);
        protected Task Save();
    }
}
