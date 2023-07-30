using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Repositories;

namespace ToDoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        public TaskRepository _taskRepository { get; set; }

        public TaskController(TaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet("get-all-tasks")]
        public async Task<IActionResult> GetTasks()
        {
            return Ok(await _taskRepository.GetAllAsync());
        }

        [HttpGet("get-task/{id}")]
        public async Task<IActionResult> GetTask(int id)
        {
            if (!_taskRepository.EntityExists(c => c.Id == id))
            {
                return NotFound();
            }
            return Ok(await _taskRepository.GetByIdAsync(id));
        }

        [HttpGet("get-all-tasks-by-task-list/{taskListId}")]
        public async Task<IActionResult> GetTasks(int taskListId, bool? isComplete, int? categoryId)
        {
            return Ok(await _taskRepository.GetTasksByTaskListAsync(taskListId, isComplete, categoryId));
        }

        [HttpPost("post-task")]
        public async Task<IActionResult> PostTask([FromBody] Models.Task task)
        {
            await _taskRepository.CreateAsync(task);
            return CreatedAtAction("GetTask", new { id = task.Id }, task);
        }

        [HttpPut("update-task/{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] Models.Task task)
        {
            if (task.Id != id) { return BadRequest(); }
            await _taskRepository.UpdateAsync(task);
            return NoContent();
        }

        [HttpDelete("delete-task/{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var tasklist = await _taskRepository.DeleteAsync(id);
            if (tasklist == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
