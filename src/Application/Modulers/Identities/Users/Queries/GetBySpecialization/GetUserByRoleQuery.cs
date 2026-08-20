using Alkonof_Backend.Application.Modulers.Identities.Users.Dtos;
using Alkonof_Backend.Domain.Entities.Identity.Enum;

namespace Alkonof_Backend.Application.Modulers.Identities.Users.Queries.GetBySpecialization;

public sealed record GetUserBySpecializationQuery(Specialization Specialization) : IRequest<List<UserDto>>;
