namespace BusinessBackendApi.Infra.Interfaces
{
    public interface IBaseCrud<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity?> GetById(int id);
        void DeleteById(int id);
        void Save(TEntity entity);
        void Update(TEntity entity);
        Task<bool> Exist(int id);
    }
}
