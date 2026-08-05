using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;
using MediatR;
using System.Collections.Generic;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Queries.GetResponsiblesByProjectId;

public sealed record GetResponsiblesByProjectIdQuery(Guid ProjectId) : IRequest<List<ProjectStaffDto>>;
