using ClassLibrary.Models;
using ClassLibrary.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController(GamesRepository repository) : ControllerBase
    {
        private readonly GamesRepository _repository = repository;

        [HttpGet]
        public IActionResult Get()
            => Ok(_repository.GetAll());

        [HttpGet("{id}")]
        public IActionResult Get(int id)
            => Ok(_repository.GetById(id));

        [HttpPost]
        public IActionResult Post([FromBody] Game game)
        {
            try
            {
                _repository.Create(game);
            }
            catch
            {
                return BadRequest();
            }
            return Created();

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Game game)
        {
            if (id != game.Id)
                return NotFound();
            try
            {
                _repository.Update(game);
            }
            catch
            {
                return BadRequest();
            }
                return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _repository.Delete(id);
            }
            catch
            {
                return BadRequest();
            }
            return NoContent();

        }
    }
}
