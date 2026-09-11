using MediatR;
using TaskManagement.Application.Interfaces;
using TaskManagement.Application.Tasks;
namespace TaskManagement.Application.Tasks.Queries.GetTaskById;
public class GetTaskByIdQueryHandler
    : IRequestHandler<GetTaskByIdQuery, object?>
{
    private readonly ITaskRepository _taskRepository;
    public GetTaskByIdQueryHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }
    public async Task<object?> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        var task = await _taskRepository.GetByIdAsync(request.Id);
        if (task is null)
            return null;
        else
        return TaskMapper.Map(task);
    }
}
