using TaskManagement;

TaskManager manager = new TaskManager();

bool running = true;

while (running)
{
    Menu.Display();

    Console.Write("Choose: ");

    int choice = Convert.ToInt32(Console.ReadLine());

    switch (choice)
    {
        case 1:
            manager.AddTask();
            break;

        case 2:
            manager.ShowTasks();
            break;

        case 3:
            manager.UpdateTask();
            break;

        case 4:
            manager.DeleteTask();
            break;

        case 5:
            running = false;
            break;

        default:
            Console.WriteLine("Invalid Choice");
            break;
    }
}