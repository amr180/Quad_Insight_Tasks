using TaskManagement.Application.DTOs.Tasks;

namespace TaskManagement.Application.Interfaces;

public interface ITaskService
{
    Task<int> CreateAsync(CreateTaskDto dto);

    Task<IEnumerable<object>> GetAllAsync();

    Task<object?> GetByIdAsync(int id);

    Task UpdateAsync(
        int id,
        UpdateTaskDto dto);

    Task DeleteAsync(int id);

    Task UpdateStatusAsync(
        int id,
        UpdateTaskStatusDto dto);

    Task<IEnumerable<object>> GetByUserIdAsync(
        int userId);

    Task<IEnumerable<object>> GetSubTasksAsync(
        int parentTaskId);
}