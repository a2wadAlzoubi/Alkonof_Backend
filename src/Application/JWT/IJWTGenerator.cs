using Alkonof_Backend.Domain.Entities.Identity;

namespace Application.Abstractions.JWT;

public interface IJwtGenerator
{
    string Generate(User user, Guid id);
}
