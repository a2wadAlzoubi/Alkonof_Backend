using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;
using MediatR;
using System.Collections.Generic;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Queries.GetProjectByCustomerIdWithRelaited;

public sealed record GetProjectByCustomerIdWithRelaitedQuery(Guid CustomerId) : IRequest<List<ProjectWithRelationsDto>>;
