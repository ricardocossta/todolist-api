using ToDoListAPI.Models;

namespace ToDoListAPI.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(ToDoListContext context) : base(context)
        {
        }
    }
}
