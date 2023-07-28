using ToDoListAPI.Models;

namespace ToDoListAPI.Repositories
{
    public class CategoryRepository : BaseRepository<Category>
    {
        public CategoryRepository(ToDoListContext context) : base(context)
        {
        }
    }
}
