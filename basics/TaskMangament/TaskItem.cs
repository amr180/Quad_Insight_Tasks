namespace TaskManagement
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public TaskItem(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
            IsCompleted = false;
        }

        public void Display()
        {
            Console.WriteLine($"Id : {Id}");
            Console.WriteLine($"Title : {Title}");
            Console.WriteLine($"Description : {Description}");
            Console.WriteLine($"Status : {(IsCompleted ? "Completed" : "Pending")}");
            Console.WriteLine("---------------------------");
        }
    }
}