using MediatR;
using TaskManagement.Application.Interfaces;
namespace TaskManagement.Application.Tasks.Commands.DeleteTask;
public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTaskCommandHandler(ITaskRepository taskRepository,IUnitOfWork unitOfWork)
    {
        _taskRepository = taskRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteTaskCommand request,CancellationToken cancellationToken)
    {
        var task = await _taskRepository.GetByIdAsync(request.Id);
        if (task is null)
            throw new KeyNotFoundException("Task not found");
        _taskRepository.Delete(task);
        await _unitOfWork.SaveChangesAsync();
    }
}
