using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Models;
using ToDoListAPI.Repositories;

namespace ToDoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public CategoryRepository _categoryRepository { get; set; }

        public CategoryController(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet("get-all-categories")]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await _categoryRepository.GetAllAsync());
        }

        [HttpGet("get-category/{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            if (!_categoryRepository.EntityExists(c => c.Id == id))
            {
                return NotFound();
            }
            return Ok(await _categoryRepository.GetByIdAsync(id));
        }

        [HttpPost("post-category")]
        public async Task<IActionResult> PostCategory([FromBody] Category category)
        {
            await _categoryRepository.CreateAsync(category);
            return CreatedAtAction("GetCategory", new {id = category.Id}, category);
        }

        [HttpPut("update-category/{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] Category category)
        {
            if (category.Id != id) { return BadRequest(); }
            await _categoryRepository.UpdateAsync(category);
            return NoContent();
        }

        [HttpDelete("delete-category/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _categoryRepository.DeleteAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
