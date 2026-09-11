using MediatR;
using DomainTaskStatus = TaskManagement.Domain.Enums.TaskStatus;

namespace TaskManagement.Application.Tasks.Commands.UpdateTaskStatus;

public record UpdateTaskStatusCommand(
    int Id,
    DomainTaskStatus Status
) : IRequest;
