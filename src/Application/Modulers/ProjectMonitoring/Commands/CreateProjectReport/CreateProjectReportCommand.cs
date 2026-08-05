using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.CreateProjectReport;

public sealed record CreateProjectReportCommand(CreateProjectReportDto CreateProjectReportDto) : IRequest<Guid>;
