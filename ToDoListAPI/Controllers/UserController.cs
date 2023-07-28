using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Models;
using ToDoListAPI.Repositories;

namespace ToDoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserRepository _userRepository { get; set; }

        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("get-all-users")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _userRepository.GetAllAsync());
        }

        [HttpGet("get-user/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            if (!_userRepository.EntityExists(c => c.Id == id))
            {
                return NotFound();
            }
            return Ok(await _userRepository.GetByIdAsync(id));
        }

        [HttpPost("post-users")]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {
            await _userRepository.CreateAsync(user);
            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        [HttpPut("update-user/{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            if (user.Id != id) { return BadRequest(); }
            await _userRepository.UpdateAsync(user);
            return NoContent();
        }

        [HttpDelete("delete-user/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.DeleteAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
