namespace TaskManagement
{
    public class TaskItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsCompleted { get; set; }

        public TaskItem(int id, string title)
        {
            Id = id;
            Title = title;
            IsCompleted = false;
        }

        public void Display()
        {
            Console.WriteLine($"{Id} - {Title} - {(IsCompleted ? "Completed" : "Pending")}");
        }
    }
}