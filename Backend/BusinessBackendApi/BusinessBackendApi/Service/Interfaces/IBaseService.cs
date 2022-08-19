namespace BusinessBackendApi.Service.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity?> GetById(int id);
        void DeleteById(int id);
        void Post(TEntity entity);
        void Update(int id, TEntity entity);
    }
}
