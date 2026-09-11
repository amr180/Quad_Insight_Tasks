using MediatR;
using TaskManagement.Application.Interfaces;
using TaskManagement.Application.Tasks;
namespace TaskManagement.Application.Tasks.Queries.GetTasksByUserId;
public class GetTasksByUserIdQueryHandler
    : IRequestHandler<GetTasksByUserIdQuery, IEnumerable<object>>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IUserRepository _userRepository;

    public GetTasksByUserIdQueryHandler(ITaskRepository taskRepository,IUserRepository userRepository)
    {_taskRepository = taskRepository;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<object>> Handle(GetTasksByUserIdQuery request,CancellationToken cancellationToken)
    {
        var userExists =await _userRepository.ExistsAsync(request.UserId);

        if (!userExists)
            throw new KeyNotFoundException("User not found.");

        var tasks =await _taskRepository.GetByUserIdAsync(request.UserId);

        return tasks.Select(TaskMapper.Map);
    }
}
