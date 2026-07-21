using FluentValidation;

namespace Alkonof_Backend.Application.Modulers.Scheduling.Commands.UpdateTimeTable;

public class UpdateTimeTableValidator : AbstractValidator<UpdateTimeTableCommand>
{
    public UpdateTimeTableValidator()
    {
        RuleFor(x => x.Dto.Id).NotEmpty().WithMessage("TimeTable ID is required for update.");
        RuleFor(x => x.Dto.DayOfWeek).IsInEnum().WithMessage("Invalid day of the week.");
        RuleFor(x => x.Dto.Hour).InclusiveBetween(0, 23).WithMessage("Hour must be between 0 and 23.");
        RuleFor(x => x.Dto.ResponsibleId).NotEmpty().WithMessage("Responsible ID is required.");
    }
}
