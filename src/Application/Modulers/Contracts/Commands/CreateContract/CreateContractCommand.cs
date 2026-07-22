using Alkonof_Backend.Application.Modulers.Contracts.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Contracts.Commands.CreateContract;

public sealed record CreateContractCommand(CreateContractDto ContractDto) : IRequest<Guid>;
