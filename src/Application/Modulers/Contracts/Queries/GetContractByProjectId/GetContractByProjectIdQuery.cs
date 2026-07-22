using Alkonof_Backend.Application.Modulers.Contracts.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Contracts.Queries.GetContractByProjectId;

public sealed record GetContractByProjectIdQuery(Guid ProjectId) : IRequest<List<ContractDto>>;
