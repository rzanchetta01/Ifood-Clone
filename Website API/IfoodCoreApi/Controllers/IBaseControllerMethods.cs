using Microsoft.AspNetCore.Mvc;

namespace IfoodCoreApi.Controllers
{
    public interface IBaseControllerMethods<TEntity> where TEntity : class
    {
        Task<ActionResult<IEnumerable<TEntity>>> GetAll();
        Task<ActionResult<TEntity>> GetById(int id);
        Task<IActionResult> Post(TEntity _class);
        Task<IActionResult> Put(int id, TEntity _class);
        Task<IActionResult> Delete(int id);
    }
}
