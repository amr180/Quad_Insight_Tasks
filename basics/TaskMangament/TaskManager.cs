namespace TaskManagement
{
    public class TaskManager
    {
        private List<TaskItem> tasks = new List<TaskItem>();

        private int nextId = 1;

        public void AddTask()
        {
            Console.Write("Enter Task Title: ");

            string title = Console.ReadLine();

            Console.Write("Enter Task Description: ");

            string description = Console.ReadLine();

            TaskItem task = new TaskItem(nextId++, title, description);

            tasks.Add(task);

            Console.WriteLine("Task Added Successfully.");
        }

        public void ShowTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No Tasks Found.");
                return;
            }

            foreach (TaskItem task in tasks)
            {
                task.Display();
                

            }
        }

        public void UpdateTask()
        {
            Console.Write("Enter Task ID: ");

            int id = Convert.ToInt32(Console.ReadLine());

            TaskItem task = tasks.Find(t => t.Id == id);

            if (task == null)
            {
                Console.WriteLine("Task Not Found.");
                return;
            }

            Console.WriteLine($"Title : {task.Title}");
            Console.WriteLine($"Description : {task.Description}");
            Console.WriteLine($"Status : {(task.IsCompleted ? "Completed" : "Pending")}");

            Console.Write("Is Completed? (y/n): ");
            if (task.IsCompleted)
            {
                Console.WriteLine("Task is already completed.");
                return;
            }
            else
            {

                string answer = Console.ReadLine();

                task.IsCompleted = answer.ToLower() == "y";

                Console.WriteLine("Task Updated.");
            }
        }

        public void DeleteTask()
        {
            Console.Write("Enter Task ID: ");

            int id = Convert.ToInt32(Console.ReadLine());

            TaskItem task = tasks.Find(t => t.Id == id);

            if (task == null)
            {
                Console.WriteLine("Task Not Found.");
                return;
            }

            tasks.Remove(task);

            Console.WriteLine("Task Deleted.");
        }
    }
}