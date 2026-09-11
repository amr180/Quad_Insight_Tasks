using MediatR;
namespace TaskManagement.Application.Tasks.Queries.GetAllTasks;
public record GetAllTasksQuery : IRequest<IEnumerable<object>>;
