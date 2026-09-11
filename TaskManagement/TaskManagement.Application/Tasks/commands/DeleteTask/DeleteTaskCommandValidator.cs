using FluentValidation;
namespace TaskManagement.Application.Tasks.Commands.DeleteTask;
public class DeleteTaskCommandValidator : AbstractValidator<DeleteTaskCommand>
{
    public DeleteTaskCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Task id must be a valid positive number ya 3am");
    }
}