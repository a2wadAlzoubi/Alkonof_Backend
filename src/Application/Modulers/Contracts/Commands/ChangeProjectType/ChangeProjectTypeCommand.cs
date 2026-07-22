using Alkonof_Backend.Domain.Entities.Contracts.Enum;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Contracts.Commands.ChangeProjectType;

public sealed record ChangeProjectTypeCommand(Guid Id, ProjectType ProjectType) : IRequest;
