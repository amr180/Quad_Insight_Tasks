using TaskMangament.TaskManagement.Application.DTOs.Tasks;
using TaskMangament.TaskMangament.Domin.Entities;

namespace TaskMangament.TaskManagement.Application.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskItem>> GetAllAsync();

        Task<TaskItem?> GetByIdAsync(int id);

        Task<TaskItem> CreateAsync(CreateTaskDto dto);

        Task<bool> UpdateAsync(int id, UpdateTaskDto dto);

        Task<bool> DeleteAsync(int id);

        Task<bool> UpdateStatusAsync(
            int id,
            UpdateTaskStatusDto dto);
    }
}
