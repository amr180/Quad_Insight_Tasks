namespace TaskMangament.TaskMangament.Domin.Entities
{
    public class TaskItem
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public TaskStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }

        //For User
        public int? UserId { get; set; }

        public User? User { get; set; }

        // Parent Task  --> maintask ==> subtask
        public int? ParentTaskId { get; set; }

        public TaskItem? ParentTask { get; set; }

        // Sub Tasks
        public ICollection<TaskItem> SubTasks { get; set; } = new List<TaskItem>();
    }
}
