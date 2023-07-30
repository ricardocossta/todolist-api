using Microsoft.EntityFrameworkCore;

namespace ToDoListAPI.Repositories
{
    public class TaskRepository : BaseRepository<Models.Task>
    {
        public TaskRepository(ToDoListContext context) : base(context)
        {
        }

        public async Task<ICollection<Models.Task>> GetTasksByTaskListAsync(int taskListId, bool? isComplete, int? categoryId)
        {
            var tasks = await _context.Tasks.Where(t => t.TaskListId == taskListId).ToListAsync();
            if (isComplete != null)
            {
                tasks = tasks.Where(t => t.IsComplete == isComplete).ToList();
            }
            if (categoryId != null)
            {
                tasks = tasks.Where(t => t.CategoryId == categoryId).ToList();
            }
            return tasks;
        }

        public async Task<int> GetNumberOfCompletedTasksAsync(int taskListId)
        {
            var tasks = await _context.Tasks.Where(t => t.TaskListId == taskListId && t.IsComplete == true).ToListAsync();
            return tasks.Count;
        }

        public async Task<int> GetNumberOfUncompletedTasksAsync(int taskListId)
        {
            var tasks = await _context.Tasks.Where(t => t.TaskListId == taskListId && t.IsComplete == false).ToListAsync();
            return tasks.Count;
        }
    }
}
