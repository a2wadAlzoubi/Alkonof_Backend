using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.UpdateProjectStaff;

public sealed record UpdateProjectStaffCommand(UpdateProjectStaffDto UpdateProjectStaffDto) : IRequest;
