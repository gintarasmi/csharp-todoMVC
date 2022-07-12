using System.ComponentModel.DataAnnotations;

namespace todoMVC.Models
{
    public class TodoItem
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = null!;
    }
}
