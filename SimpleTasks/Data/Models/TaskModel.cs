using System.ComponentModel.DataAnnotations;

namespace SimpleTasks.Data.Models
{
    public class TaskModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime Created_Time { get; set; } = DateTime.Now;
        public bool Is_Completed { get; set; } = false;
        public string User_Id { get; set; } = string.Empty;
    }
}
