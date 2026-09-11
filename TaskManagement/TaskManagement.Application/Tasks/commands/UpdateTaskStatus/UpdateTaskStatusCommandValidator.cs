using FluentValidation;

namespace TaskManagement.Application.Tasks.Commands.UpdateTaskStatus;

public class UpdateTaskStatusCommandValidator : AbstractValidator<UpdateTaskStatusCommand>
{
    public UpdateTaskStatusCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Task id must be a valid positive number.");
        RuleFor(x => x.Status).IsInEnum().WithMessage("Invalid task status");
    }
}