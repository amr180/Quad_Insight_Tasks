using MediatR;
using TaskManagement.Application.Interfaces;
namespace TaskManagement.Application.Tasks.Commands.UpdateTask;
public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateTaskCommandHandler(ITaskRepository taskRepository,
        IUserRepository userRepository,IUnitOfWork unitOfWork)
    {
        _taskRepository = taskRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task Handle( UpdateTaskCommand request,CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Title))
            throw new ArgumentException("Task title is required no comment");
        var task = await _taskRepository.GetByIdAsync(request.Id);
        if (task is null)
            throw new KeyNotFoundException("Task not found plz rakaz");
        // Check User
        if (request.UserId.HasValue)
        {
            var userExists =await _userRepository.ExistsAsync(request.UserId.Value);
            if (!userExists)throw new KeyNotFoundException("User not found try again ya 3m");
        }
        task.Update(request.Title,request.Description,request.UserId);
        _taskRepository.Update(task);
        await _unitOfWork.SaveChangesAsync();
    }
}
