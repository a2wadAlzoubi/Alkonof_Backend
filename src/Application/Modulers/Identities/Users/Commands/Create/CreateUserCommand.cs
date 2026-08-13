﻿using Alkonof_Backend.Application.Modulers.Identities.Users.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace Alkonof_Backend.Application.Modulers.Identities.Users.Commands.Create;

[Authorize]
public sealed record CreateUserCommand(CreateUserDto Dto) : IRequest<Guid>;
