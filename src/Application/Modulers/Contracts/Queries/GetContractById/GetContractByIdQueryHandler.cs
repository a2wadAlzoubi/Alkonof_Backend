using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Contracts.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Contracts.Queries.GetContractById;

public class GetContractByIdQueryHandler : IRequestHandler<GetContractByIdQuery, ContractDto?>
{
    private readonly IApplicationDbContext _context;

    public GetContractByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ContractDto?> Handle(GetContractByIdQuery request, CancellationToken cancellationToken)
    {
        var contract = await _context.Contract
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

        if (contract == null)
        {
            return null;
        }

        return new ContractDto
        {
            Id = contract.Id,
            StartedDate = contract.StartedDate,
            EndedDate = contract.EndedDate,
            PathImage = contract.PathImage,
            ProjectType = contract.ProjectType,
            Status = contract.Status,
            ProjectId = contract.ProjectId,
            // CustomerId is not directly on the contract. How to retrieve it?
            // I will leave it null for now.
            CustomerId = null 
        };
    }
}
