using TaskManagement.Domain.Enums;

namespace TaskManagement.Domain.Entities;

public class TaskItem
{
    private string _title = string.Empty;
    private string? _description;

    public int Id { get; private set; }

    public string Title
    {
        get => _title;
        private set => _title = value.Trim();
    }

    public string? Description
    {
        get => _description;
        private set => _description = value?.Trim();
    }

    public TaskManagement.Domain.Enums.TaskStatus Status
    {
        get;
        private set;
    }

    public DateTime CreatedAt { get; private set; }

    // User Relationship
    public int UserId { get; private set; }
    public User User { get; private set; } = null!;

    // Parent Task Relationship
    public int? ParentTaskId { get; private set; }

    public TaskItem? ParentTask { get; private set; }

    // Sub Tasks
    public ICollection<TaskItem> SubTasks { get; private set; }
        = new List<TaskItem>();

    // EF Core
    private TaskItem()
    {
    }

    public TaskItem(
        string title,
        int userId,
        string? description = null,
        int? parentTaskId = null)
    {
        SetTitle(title);
        SetDescription(description);
       
        if (userId <= 0)
            throw new ArgumentException("User ID must be valid.");

        UserId = userId;
        ParentTaskId = parentTaskId;

        Status = Enums.TaskStatus.Pending;
        CreatedAt = DateTime.UtcNow;
    }

    public void Update(
        string title,
        string? description,
        int userId)
    {
        SetTitle(title);
        SetDescription(description);

        UserId = userId;
    }

    public void Complete()
    {
        Status =
            TaskManagement.Domain.Enums.TaskStatus.Completed;
    }

    public void Reopen()
    {
        Status =
            TaskManagement.Domain.Enums.TaskStatus.Pending;
    }

    private void SetTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException(
                "Task title cannot be empty.");

        _title = title.Trim();
    }

    private void SetDescription(string? description)
    {
        _description = description?.Trim();
    }
}