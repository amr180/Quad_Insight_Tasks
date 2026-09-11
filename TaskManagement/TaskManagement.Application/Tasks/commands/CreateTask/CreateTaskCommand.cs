using MediatR;
namespace TaskManagement.Application.Tasks.Commands.CreateTask;
public record CreateTaskCommand(string Title,string? Description,int? UserId) : IRequest<int>;
