using MediatR;
namespace TaskManagement.Application.Tasks.Queries.GetTaskById;
public record GetTaskByIdQuery(int Id) : IRequest<object?>;
