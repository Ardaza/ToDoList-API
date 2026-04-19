using Microsoft.AspNetCore.Mvc;
using ToDoList.Dto;
using ToDoList.Models;
using ToDoList.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace ToDoList.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoListRepository _repository;

        public ToDoController(IToDoListRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var todos = await _repository.GetAllAsync();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var todo = await _repository.GetByIdAsync(id);
            if (todo == null)
            {
                return NotFound(new { message = $"Todolist dengan id {id} tidak ditemukan" });
            }

            return Ok(todo);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateToDoDto dto)
        {
            var todo = new ToDoItem
            {
                Title = dto.Title,
                Description = dto.Description,
            };

            var created = await _repository.CreateAsync(todo);

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateToDoDto dto)
        {
            var todo = new ToDoItem
            {
                Title = dto.Title,
                Description = dto.Description,
                isCompleted = dto.isCompleted
            };

            var updated = await _repository.UpdateAsync(id, todo);
            if (updated == null)
            {
                return NotFound(new { message = $"Todolist dengan id {id} tidak ditemukan" });
            }

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repository.DeleteAsync(id);
            if (!result)
            {
                return NotFound(new { message = $"Todolist dengan id {id} tidak ditemukan" });
            }

            return NoContent();
        }
    }
}
