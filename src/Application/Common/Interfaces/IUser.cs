using Alkonof_Backend.Domain.Entities;

namespace Alkonof_Backend.Application.Common.Interfaces;

public interface IUser
{
    string? Id { get; }
    List<string>? Roles { get; }

}
