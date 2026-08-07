using Alkonof_Backend.Application.Modulers.Complaints.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Complaints.Commands.UpdateResolution;

public sealed record UpdateResolutionCommand(UpdateResolutionDto Dto) : IRequest;
