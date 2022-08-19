using BusinessBackendApi.Model;
using BusinessBackendApi.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BusinessBackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly RestaurantService service;

        public RestaurantController(RestaurantService service)
        {
            this.service = service;
        }



        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurant>>> Get()
        {
            return Ok(value: await service.GetAll());
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> Get(int id)
        {
            return Ok(value: await service.GetById(id));
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post([FromBody] Restaurant product)
        {
            service.Post(product);
            return Ok();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Restaurant product)
        {
            service.Update(id, product);
            return Ok();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            service.DeleteById(id);
            return Ok();
        }
    }
}
