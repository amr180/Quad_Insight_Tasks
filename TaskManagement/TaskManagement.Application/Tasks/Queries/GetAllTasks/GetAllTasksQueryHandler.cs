using MediatR;
using TaskManagement.Application.Interfaces;
using TaskManagement.Application.Tasks;

namespace TaskManagement.Application.Tasks.Queries.GetAllTasks;
public class GetAllTasksQueryHandler: IRequestHandler<GetAllTasksQuery, IEnumerable<object>>
{
    private readonly ITaskRepository _taskRepository;
    public GetAllTasksQueryHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }
    public async Task<IEnumerable<object>> Handle(GetAllTasksQuery request,CancellationToken cancellationToken)
    {
        var tasks = await _taskRepository.GetAllAsync();
        return tasks.Select(TaskMapper.Map);
    }
}
