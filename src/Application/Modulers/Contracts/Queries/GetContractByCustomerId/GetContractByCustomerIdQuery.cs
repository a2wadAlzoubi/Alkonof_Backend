using Alkonof_Backend.Application.Modulers.Contracts.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Contracts.Queries.GetContractByCustomerId;

public sealed record GetContractByCustomerIdQuery(Guid CustomerId) : IRequest<List<ContractDto>>;
