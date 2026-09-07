using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Interfaces;

public interface ITaskRepository
{
    Task<TaskItem?> GetByIdAsync(int id);

    Task<IEnumerable<TaskItem>> GetAllAsync();

    Task<IEnumerable<TaskItem>> GetByUserIdAsync(int userId);

    Task AddAsync(TaskItem task);

    void Update(TaskItem task);

    void Delete(TaskItem task);

    Task<bool> ExistsAsync(int id);
}