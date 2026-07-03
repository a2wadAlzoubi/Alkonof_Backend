using Alkonof_Backend.Domain.Entities;

namespace Application.Abstractions.JWT;

public interface IJwtGenerator
{
    string Generate(User user, Guid id);
}
