using System.ComponentModel.DataAnnotations;

namespace ToDoListAPI.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsComplete { get; set; }
        public DateTime DueDate { get; set; }
        public int TaskListId { get; set; }
        public TaskList TaskList { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
