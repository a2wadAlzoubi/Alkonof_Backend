using Alkonof_Backend.Application.Modulers.Contracts.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Contracts.Commands.UpdateContract;

public sealed record UpdateContractCommand(Guid Id, ContractDto ContractDto) : IRequest;
