using Alkonof_Backend.Application.Modulers.Complaints.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Complaints.Queries.GetComplainById;

public sealed record GetComplainByIdQuery(Guid Id) : IRequest<ComplainDto?>;
