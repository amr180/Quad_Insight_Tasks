using FluentValidation;
namespace TaskManagement.Application.Tasks.Commands.UpdateTask;
public class UpdateTaskCommandValidator : AbstractValidator<UpdateTaskCommand>
{
    public UpdateTaskCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Task id must be a valid positive number ya 3am");
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Task title is required plz rakaz")
            .MaximumLength(200).WithMessage("Task title must not exceed 200 characters.");

        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage("Description must not exceed 1000 characters.");
        RuleFor(x => x.UserId)
            .GreaterThan(0).WithMessage("UserId must be a valid positive number.")
            .When(x => x.UserId.HasValue);
    }
}