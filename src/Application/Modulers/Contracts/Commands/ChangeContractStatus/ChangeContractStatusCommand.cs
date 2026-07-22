using Alkonof_Backend.Domain.Entities.Contracts.Enum;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Contracts.Commands.ChangeContractStatus;

public sealed record ChangeContractStatusCommand(Guid Id, ContractStatus Status) : IRequest;
