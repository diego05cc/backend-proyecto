using backend_proyecto.model;
using backend_proyecto.services;
using Microsoft.AspNetCore.Mvc;
using backend_proyecto.DTOs;

namespace backend_proyecto.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasksService _tasksService;

        public TasksController(ITasksService tasksService)
        {
            _tasksService = tasksService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<DTOTasks>>> GetAllTasks()
        {
            var tasks = await _tasksService.GetAllTasksAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DTOTasks>> GetTaskById(int id)
        {
            var task = await _tasksService.GetTaskByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DTOTasks>> CreateTask(DTOTasks task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _tasksService.CreateTaskAsync(task);
            return CreatedAtAction("GetTaskById", new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateTask(int id, DTOTasks task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }

            await _tasksService.UpdateTaskAsync(task);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteTask(int id)
        {
            await _tasksService.SoftDeleteTaskAsync(id);
            return NoContent();
        }
    }
}