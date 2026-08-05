using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.CreateProjectStaff;

public sealed record CreateProjectStaffCommand(CreateProjectStaffDto CreateProjectStaffDto) : IRequest<Guid>;
