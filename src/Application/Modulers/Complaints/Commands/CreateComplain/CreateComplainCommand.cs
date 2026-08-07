using Alkonof_Backend.Application.Modulers.Complaints.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Complaints.Commands.CreateComplain;

public sealed record CreateComplainCommand(CreateComplainDto Dto) : IRequest<Guid?>;
