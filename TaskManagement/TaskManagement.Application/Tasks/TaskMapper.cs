using TaskManagement.Domain.Entities;
namespace TaskManagement.Application.Tasks;
public static class TaskMapper
{
    public static object Map(TaskItem task)
    {
        return new{task.Id,task.Title,task.Description,task.Status,
            task.CreatedAt,
            User = task.User == null? null: new
                {
                    task.User.Id,
                    task.User.Name,
                    task.User.Email
                }
        };
    }
}
