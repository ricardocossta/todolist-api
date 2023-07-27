using System.ComponentModel.DataAnnotations;

namespace ToDoListAPI.Models
{
    public class TaskList
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Task> Tasks { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
