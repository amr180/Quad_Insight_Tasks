using MediatR;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;
namespace TaskManagement.Application.Tasks.Commands.CreateTask;
public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, int>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateTaskCommandHandler(ITaskRepository taskRepository,IUserRepository userRepository,IUnitOfWork unitOfWork)
    {
        _taskRepository = taskRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<int> Handle(CreateTaskCommand request,CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Title))
            throw new ArgumentException("Task title is required.");
        // Check User
        if (request.UserId.HasValue)
        {
            var userExists =await _userRepository.ExistsAsync(request.UserId.Value);
            if (!userExists)
                throw new KeyNotFoundException("User not found.");
        }
        var task = new TaskItem(request.Title, request.Description,request.UserId);

        await _taskRepository.AddAsync(task);
        await _unitOfWork.SaveChangesAsync();
        return task.Id;
    }
}
