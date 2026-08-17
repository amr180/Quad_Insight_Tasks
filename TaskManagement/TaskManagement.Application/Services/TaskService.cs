using TaskManagement.Application.DTOs.Tasks;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;
using DomainTaskStatus = TaskManagement.Domain.Enums.TaskStatus;

namespace TaskManagement.Application.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TaskService(
        ITaskRepository taskRepository,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork)
    {
        _taskRepository = taskRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    // =========================
    // Create Task
    // =========================

    public async Task<int> CreateAsync(CreateTaskDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Title))
            throw new ArgumentException("Task title is required.");

        // Check User
        if (dto.UserId.HasValue)
        {
            var userExists =
                await _userRepository.ExistsAsync(dto.UserId.Value);

            if (!userExists)
                throw new KeyNotFoundException("User not found.");
        }

        // Check Parent Task
        if (dto.ParentTaskId.HasValue)
        {
            var parentExists =
                await _taskRepository.ExistsAsync(dto.ParentTaskId.Value);

            if (!parentExists)
                throw new KeyNotFoundException(
                    "Parent task not found.");
        }

        var task = new TaskItem(
            dto.Title,
            dto.Description,
            dto.UserId,
            dto.ParentTaskId);

        await _taskRepository.AddAsync(task);

        await _unitOfWork.SaveChangesAsync();

        return task.Id;
    }

    // =========================
    // Get All Tasks
    // =========================

    public async Task<IEnumerable<object>> GetAllAsync()
    {
        var tasks = await _taskRepository.GetAllAsync();

        return tasks.Select(MapTask);
    }

    // =========================
    // Get Task By Id
    // =========================

    public async Task<object?> GetByIdAsync(int id)
    {
        var task = await _taskRepository.GetByIdAsync(id);

        if (task is null)
            return null;

        return MapTask(task);
    }

    // =========================
    // Update Task
    // =========================

    public async Task UpdateAsync(
        int id,
        UpdateTaskDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Title))
            throw new ArgumentException(
                "Task title is required.");

        var task = await _taskRepository.GetByIdAsync(id);

        if (task is null)
            throw new KeyNotFoundException(
                "Task not found.");

        // Check User
        if (dto.UserId.HasValue)
        {
            var userExists =
                await _userRepository.ExistsAsync(dto.UserId.Value);

            if (!userExists)
                throw new KeyNotFoundException(
                    "User not found.");
        }

        task.Update(
            dto.Title,
            dto.Description,
            dto.UserId);

        _taskRepository.Update(task);

        await _unitOfWork.SaveChangesAsync();
    }

    // =========================
    // Delete Task
    // =========================

    public async Task DeleteAsync(int id)
    {
        var task = await _taskRepository.GetByIdAsync(id);

        if (task is null)
            throw new KeyNotFoundException(
                "Task not found.");

        var subTasks =
            await _taskRepository.GetSubTasksAsync(id);

        if (subTasks.Any())
        {
            throw new InvalidOperationException(
                "Cannot delete a task that has sub tasks.");
        }

        _taskRepository.Delete(task);

        await _unitOfWork.SaveChangesAsync();
    }

    // =========================
    // Update Status
    // =========================

    public async Task UpdateStatusAsync(
        int id,
        UpdateTaskStatusDto dto)
    {
        var task = await _taskRepository.GetByIdAsync(id);

        if (task is null)
            throw new KeyNotFoundException(
                "Task not found.");

        switch (dto.Status)
        {
            case DomainTaskStatus.Completed:

                task.Complete();

                break;

            case DomainTaskStatus.Pending:

                task.Reopen();

                break;

            default:

                throw new ArgumentException(
                    "Invalid task status.");
        }

        _taskRepository.Update(task);

        await _unitOfWork.SaveChangesAsync();
    }

    // =========================
    // Get Tasks By User
    // =========================

    public async Task<IEnumerable<object>> GetByUserIdAsync(
        int userId)
    {
        var userExists =
            await _userRepository.ExistsAsync(userId);

        if (!userExists)
            throw new KeyNotFoundException(
                "User not found.");

        var tasks =
            await _taskRepository.GetByUserIdAsync(userId);

        return tasks.Select(MapTask);
    }

    // =========================
    // Get Sub Tasks
    // =========================

    public async Task<IEnumerable<object>> GetSubTasksAsync(
        int parentTaskId)
    {
        var parentExists =
            await _taskRepository.ExistsAsync(parentTaskId);

        if (!parentExists)
            throw new KeyNotFoundException(
                "Parent task not found.");

        var subTasks =
            await _taskRepository.GetSubTasksAsync(parentTaskId);

        return subTasks.Select(MapTask);
    }

    // =========================
    // Mapping
    // =========================

    private static object MapTask(TaskItem task)
    {
        return new
        {
            task.Id,
            task.Title,
            task.Description,
            task.Status,
            task.CreatedAt,

            User = task.User == null
                ? null
                : new
                {
                    task.User.Id,
                    task.User.Name,
                    task.User.Email
                },

            ParentTaskId = task.ParentTaskId,

            SubTasks = task.SubTasks.Select(subTask => new
            {
                subTask.Id,
                subTask.Title,
                subTask.Description,
                subTask.Status,
                subTask.UserId,
                subTask.ParentTaskId,
                subTask.CreatedAt
            })
        };
    }
}