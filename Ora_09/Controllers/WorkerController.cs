using Microsoft.AspNetCore.Mvc;
using Ora_06.Logic;
using Ora_06.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ora_09.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly ILogic<Worker> _workerLogic;

        public WorkerController(ILogic<Worker> workerLogic)
        {
            _workerLogic = workerLogic;
        }

        // GET: api/<WorkerController>
        [HttpGet]
        public IEnumerable<Worker> Get()
        {
            return _workerLogic.GetAll();
        }

        // GET api/<WorkerController>/5
        [HttpGet("{id}")]
        public Worker Get(string id)
        {
            return _workerLogic.Get(id);
        }

        // POST api/<WorkerController>
        [HttpPost]
        public void Post([FromBody] Worker value)
        {
            _workerLogic.Create(value);
        }

        // PUT api/<WorkerController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Worker value)
        {
            //_workerLogic.Update(id, value);
        }

        // DELETE api/<WorkerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                _workerLogic.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
