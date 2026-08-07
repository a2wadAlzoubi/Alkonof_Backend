using Alkonof_Backend.Application.Modulers.Complaints.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Complaints.Queries.GetResolutionByComplainId;

public sealed record GetResolutionByComplainIdQuery(Guid ComplintId) : IRequest<List<ResolutionDto>>;
