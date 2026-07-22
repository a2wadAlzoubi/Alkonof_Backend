using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Contracts.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Contracts.Queries.GetContractByProjectId;

public class GetContractByProjectIdQueryHandler : IRequestHandler<GetContractByProjectIdQuery, List<ContractDto>>
{
    private readonly IApplicationDbContext _context;

    public GetContractByProjectIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ContractDto>> Handle(GetContractByProjectIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Contract
            .AsNoTracking()
            .Where(c => c.ProjectId == request.ProjectId)
            .Select(contract => new ContractDto
            {
                Id = contract.Id,
                StartedDate = contract.StartedDate,
                EndedDate = contract.EndedDate,
                PathImage = contract.PathImage,
                ProjectType = contract.ProjectType,
                Status = contract.Status,
                ProjectId = contract.ProjectId,
                CustomerId = null
            })
            .ToListAsync(cancellationToken);
    }
}
