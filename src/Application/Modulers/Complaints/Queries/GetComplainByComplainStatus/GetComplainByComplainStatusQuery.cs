using Alkonof_Backend.Application.Modulers.Complaints.Dtos;
using Alkonof_Backend.Domain.Entities.Complains.Enum;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Complaints.Queries.GetComplainByComplainStatus;

public sealed record GetComplainByComplainStatusQuery(ComplainStatus Status) : IRequest<List<ComplainDto>>;
