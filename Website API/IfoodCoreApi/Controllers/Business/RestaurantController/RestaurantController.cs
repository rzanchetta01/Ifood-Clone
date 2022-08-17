using IfoodCoreApi.Models.Business.Restaurants;
using IfoodCoreApi.Services.BusinessService.RestaurantService;
using Microsoft.AspNetCore.Mvc;

namespace IfoodCoreApi.Controllers.Business
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase, IRestaurantApiMethods
    {
        private readonly RestaurantService service;

        public RestaurantController(RestaurantService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetAll()
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
        public async Task<ActionResult<Restaurant>> GetById(int id)
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
        public async Task<IActionResult> Post(Restaurant restaurant)
        {
            try
            {
                await service.Post(restaurant);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Restaurant restaurant)
        {
            try
            {
                await service.Put(id, restaurant);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
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
    }
}
