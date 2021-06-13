using CodingTest.EF_Operation;
using CodingTest.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CodingTest.Controllers
{
    /// <summary>
    /// Generic Base controller for handling all CRUD operations
    /// All API controllers will implement this Base controller
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : Controller where T : class, IBaseData
    {
        private IGenericRepository<T> _repository;

        public BaseController(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Find(Guid id)
        {
            var record = _repository.GetById(id);
            if (record == null)
                return NotFound();
            return Ok(record);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] T record)
        {
            _repository.Insert(record);
            if (await _repository.SaveAsync() == 0)
                return BadRequest();

            return CreatedAtAction("Find", new { id = record.Id }, record);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] T record)
        {
            if (id != record.Id)
                return BadRequest();

            //var entityObj = _repository.GetById(id);
            _repository.Update(record);
            if (await _repository.SaveAsync() == 0)
                return BadRequest();

            return Ok(record);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var record = _repository.GetById(id);
            if (record == null)
                return Problem("No such record in database.");
            _repository.Delete(id);
            if (await _repository.SaveAsync() == 0)
                return BadRequest();

            return NoContent();
        }
    }
}
