using TaskMangament.TaskMangament.Domin.Entities;

namespace TaskMangament.TaskManagement.Application.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskItem>> GetAllAsync();

        Task<TaskItem?> GetByIdAsync(int id);

        Task AddAsync(TaskItem task);

        Task UpdateAsync(TaskItem task);

        Task DeleteAsync(TaskItem task);
    }
}
