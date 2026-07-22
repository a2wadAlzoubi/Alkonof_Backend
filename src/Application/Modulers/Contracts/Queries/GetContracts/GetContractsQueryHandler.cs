using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Contracts.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Contracts.Queries.GetContracts;

public class GetContractsQueryHandler : IRequestHandler<GetContractsQuery, List<ContractDto>>
{
    private readonly IApplicationDbContext _context;

    public GetContractsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ContractDto>> Handle(GetContractsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Contract
            .AsNoTracking()
            .Select(contract => new ContractDto
            {
                Id = contract.Id,
                StartedDate = contract.StartedDate,
                EndedDate = contract.EndedDate,
                PathImage = contract.PathImage,
                ProjectType = contract.ProjectType,
                Status = contract.Status,
                ProjectId = contract.ProjectId,
                CustomerId = null // Again, CustomerId is not directly available.
            })
            .ToListAsync(cancellationToken);
    }
}
