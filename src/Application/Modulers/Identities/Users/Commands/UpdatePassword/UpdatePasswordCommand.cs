using Alkonof_Backend.Application.Modulers.Identities.Users.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Identities.Users.Commands.UpdatePassword;

public sealed record UpdatePasswordCommand(UpdatePasswordDto Dto) : IRequest;
