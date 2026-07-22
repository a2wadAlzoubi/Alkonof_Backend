using Alkonof_Backend.Application.Modulers.Contracts.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Contracts.Queries.GetContractById;

public sealed record GetContractByIdQuery(Guid Id) : IRequest<ContractDto?>;
