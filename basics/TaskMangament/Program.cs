using TaskManagement;

TaskManager manager = new TaskManager();

bool running = true;

while (running)
{
    Menu.Display();

    Console.Write("Choose: ");
    
    int choice = Convert.ToInt32(Console.ReadLine());
    if(choice != 1 && choice != 2 && choice != 3 && choice != 4 && choice != 5)
    {
        Console.WriteLine("Invalid Choice");
        continue;
    }

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