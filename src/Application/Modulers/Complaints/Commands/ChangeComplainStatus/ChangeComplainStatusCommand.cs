using Alkonof_Backend.Application.Modulers.Complaints.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Complaints.Commands.ChangeComplainStatus;

public sealed record ChangeComplainStatusCommand(ChangeComplainStatusDto Dto) : IRequest;
