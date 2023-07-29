using ToDoListAPI.Models;

namespace ToDoListAPI.Repositories
{
    public class TaskRepository : BaseRepository<Models.Task>
    {
        public TaskRepository(ToDoListContext context) : base(context)
        {
        }
    }
}
