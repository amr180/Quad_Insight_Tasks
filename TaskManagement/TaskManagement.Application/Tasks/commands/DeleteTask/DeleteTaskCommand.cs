using MediatR;
namespace TaskManagement.Application.Tasks.Commands.DeleteTask;
public record DeleteTaskCommand(int Id) : IRequest;
