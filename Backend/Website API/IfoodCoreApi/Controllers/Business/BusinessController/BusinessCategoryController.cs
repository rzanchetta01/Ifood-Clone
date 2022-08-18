using IfoodCoreApi.Models.Business;
using IfoodCoreApi.Services.BusinessService;
using Microsoft.AspNetCore.Mvc;

namespace IfoodCoreApi.Controllers.Business.BusinessController
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusinessCategoryController : ControllerBase, IBaseControllerMethods<BusinessCategory>
    {
        private readonly BusinessCategoryService service;

        public BusinessCategoryController(BusinessCategoryService service)
        {
            this.service = service;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await service.DeleteById(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<BusinessCategory>>> GetAll()
        {
            try
            {
                return Ok(await service.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessCategory>> GetById(int id)
        {
            try
            {
                return Ok(await service.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(BusinessCategory category)
        {
            try
            {
                await service.Post(category);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, BusinessCategory category)
        {
            try
            {
                await service.Put(id, category);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
