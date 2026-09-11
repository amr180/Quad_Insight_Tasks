using MediatR;
namespace TaskManagement.Application.Tasks.Queries.GetTasksByUserId;
public record GetTasksByUserIdQuery(int UserId) : IRequest<IEnumerable<object>>;
