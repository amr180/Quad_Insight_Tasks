using MediatR;
namespace TaskManagement.Application.Tasks.Commands.UpdateTask;
public record UpdateTaskCommand(int Id,string Title,string? Description,int? UserId) : IRequest;
