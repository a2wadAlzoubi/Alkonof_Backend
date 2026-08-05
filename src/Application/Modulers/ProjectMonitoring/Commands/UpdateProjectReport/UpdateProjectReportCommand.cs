using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.UpdateProjectReport;

public sealed record UpdateProjectReportCommand(UpdateProjectReportDto UpdateProjectReportDto) : IRequest;
