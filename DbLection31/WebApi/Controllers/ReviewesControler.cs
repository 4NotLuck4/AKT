using DbLibrary;
using DbLibrary.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewesControler(ReviewsRepository repository) : ControllerBase
    {
        private readonly ReviewsRepository _repository = repository;

        // GET: api/<ReviewesControler>
        [HttpGet]
        public IActionResult Get()
            =>Ok(_repository.GetAll());

        // GET api/<ReviewesControler>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
            => Ok(_repository.GetById(id));

        // POST api/<ReviewesControler>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ReviewesControler>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Review review)
        {
            if (id != review.Id)
                return NotFound();
            _repository.Update(review);
            return NoContent();
        }

        // DELETE api/<ReviewesControler>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return NoContent();
        }
    }
}
