using ToDoListAPI.Models;

namespace ToDoListAPI.Repositories
{
    public class TaskListRepository : BaseRepository<TaskList>
    {
        public TaskListRepository(ToDoListContext context) : base(context)
        {
        }
    }
}
