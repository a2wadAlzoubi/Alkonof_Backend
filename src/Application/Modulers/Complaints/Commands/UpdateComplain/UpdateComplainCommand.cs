using Alkonof_Backend.Application.Modulers.Complaints.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Complaints.Commands.UpdateComplain;

public sealed record UpdateComplainCommand(UpdateComplainDto Dto) : IRequest;
