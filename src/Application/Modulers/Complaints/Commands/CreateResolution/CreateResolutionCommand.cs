using Alkonof_Backend.Application.Modulers.Complaints.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Complaints.Commands.CreateResolution;

public sealed record CreateResolutionCommand(CreateResolutionDto Dto) : IRequest<Guid?>;
