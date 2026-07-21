using FluentValidation;

namespace Alkonof_Backend.Application.Modulers.Scheduling.Commands.CreateTimeTable;

public class CreateTimeTableValidator : AbstractValidator<CreateTimeTableCommand>
{
    public CreateTimeTableValidator()
    {
        RuleForEach(x => x.Dtos).ChildRules(dto =>
        {
            dto.RuleFor(d => d.DayOfWeek).IsInEnum().WithMessage("Invalid day of the week.");
            dto.RuleFor(d => d.Hour).InclusiveBetween(0, 23).WithMessage("Hour must be between 0 and 23.");
            dto.RuleFor(d => d.ResponsibleId).NotEmpty().WithMessage("Responsible ID is required.");
        });
    }
}
