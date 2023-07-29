using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Models;
using ToDoListAPI.Repositories;

namespace ToDoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskListController : ControllerBase
    {
        public TaskListRepository _taskListRepository { get; set; }

        public TaskListController(TaskListRepository taskListRepository)
        {
            _taskListRepository = taskListRepository;
        }

        [HttpGet("get-all-task-lists")]
        public async Task<IActionResult> GetTaskLists()
        {
            return Ok(await _taskListRepository.GetAllAsync());
        }

        [HttpGet("get-task-list/{id}")]
        public async Task<IActionResult> GetTaskList(int id)
        {
            if (!_taskListRepository.EntityExists(c => c.Id == id))
            {
                return NotFound();
            }
            return Ok(await _taskListRepository.GetByIdAsync(id));
        }

        [HttpPost("post-task-list")]
        public async Task<IActionResult> PostTaskList([FromBody] TaskList taskList)
        {
            await _taskListRepository.CreateAsync(taskList);
            return CreatedAtAction("GetTaskList", new { id = taskList.Id }, taskList);
        }

        [HttpPut("update-task-list/{id}")]
        public async Task<IActionResult> UpdateTaskList(int id, [FromBody] TaskList taskList)
        {
            if (taskList.Id != id) { return BadRequest(); }
            await _taskListRepository.UpdateAsync(taskList);
            return NoContent();
        }

        [HttpDelete("delete-task-list/{id}")]
        public async Task<IActionResult> DeleteTaskList(int id)
        {
            var tasklist = await _taskListRepository.DeleteAsync(id);
            if (tasklist == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
