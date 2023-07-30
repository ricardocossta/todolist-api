using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using ToDoListAPI.Models;

namespace ToDoListAPI.Repositories
{
    public class TaskListRepository : BaseRepository<TaskList>
    {
        public TaskListRepository(ToDoListContext context) : base(context)
        {
        }

        public async Task<ICollection<TaskList>> GetTaskListsByUserAsync(int userId)
        {
            return await _context.TaskLists.Where(tl => tl.UserId == userId).ToListAsync();
        }
    }
}
