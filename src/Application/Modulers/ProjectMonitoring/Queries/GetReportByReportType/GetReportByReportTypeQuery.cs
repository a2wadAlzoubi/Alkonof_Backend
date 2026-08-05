using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;
using MediatR;
using System.Collections.Generic;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Queries.GetReportByReportType;

public sealed record GetReportByReportTypeQuery(string ReportType) : IRequest<List<ProjectReportDto>>;
