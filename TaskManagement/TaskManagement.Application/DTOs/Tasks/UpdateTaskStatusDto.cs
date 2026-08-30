using DomainTaskStatus = TaskManagement.Domain.Enums.TaskStatus;

namespace TaskManagement.Application.DTOs.Tasks;

public class UpdateTaskStatusDto
{
    public DomainTaskStatus Status { get; set; }
}