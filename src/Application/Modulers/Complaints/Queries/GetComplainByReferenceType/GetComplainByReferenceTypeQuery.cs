using Alkonof_Backend.Application.Modulers.Complaints.Dtos;
using Alkonof_Backend.Domain.Enums;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Complaints.Queries.GetComplainByReferenceType;

public sealed record GetComplainByReferenceTypeQuery(ReferenceType ReferenceType) : IRequest<List<ComplainDto>>;
