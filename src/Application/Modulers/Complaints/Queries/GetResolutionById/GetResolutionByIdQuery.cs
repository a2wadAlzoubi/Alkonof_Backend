using Alkonof_Backend.Application.Modulers.Complaints.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Complaints.Queries.GetResolutionById;

public sealed record GetResolutionByIdQuery(Guid Id) : IRequest<ResolutionDto?>;
