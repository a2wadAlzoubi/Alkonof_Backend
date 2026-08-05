using MediatR;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.RemoveProjectStaff;

public sealed record RemoveProjectStaffCommand(Guid Id) : IRequest;
