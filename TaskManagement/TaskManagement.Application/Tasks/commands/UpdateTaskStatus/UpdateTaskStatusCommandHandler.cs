using MediatR;
using TaskManagement.Application.Interfaces;
using DomainTaskStatus = TaskManagement.Domain.Enums.TaskStatus;
namespace TaskManagement.Application.Tasks.Commands.UpdateTaskStatus;
public class UpdateTaskStatusCommandHandler : IRequestHandler<UpdateTaskStatusCommand>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateTaskStatusCommandHandler(
        ITaskRepository taskRepository,IUnitOfWork unitOfWork)
    {
        _taskRepository = taskRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(
        UpdateTaskStatusCommand request,
        CancellationToken cancellationToken)
    {
        var task = await _taskRepository.GetByIdAsync(request.Id);

        if (task is null)
            throw new KeyNotFoundException("Task not found.");

        switch (request.Status)
        {
            case DomainTaskStatus.Completed:
                task.Complete();
                break;

            case DomainTaskStatus.Pending:
                task.Reopen();
                break;

            default:
                throw new ArgumentException("Invalid task status.");
        }

        _taskRepository.Update(task);

        await _unitOfWork.SaveChangesAsync();
    }
}
