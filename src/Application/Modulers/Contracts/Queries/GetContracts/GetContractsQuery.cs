using Alkonof_Backend.Application.Modulers.Contracts.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Contracts.Queries.GetContracts;

public sealed record GetContractsQuery : IRequest<List<ContractDto>>;
