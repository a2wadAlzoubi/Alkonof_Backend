using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Contracts.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Contracts.Queries.GetContractByCustomerId;

public class GetContractByCustomerIdQueryHandler : IRequestHandler<GetContractByCustomerIdQuery, List<ContractDto>>
{
    private readonly IApplicationDbContext _context;

    public GetContractByCustomerIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ContractDto>> Handle(GetContractByCustomerIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Contract
            .AsNoTracking()
            .Include(c => c.Booking)
            .Where(c => c.Booking != null && c.Booking.CustomerId == request.CustomerId)
            .Select(contract => new ContractDto
            {
                Id = contract.Id,
                StartedDate = contract.StartedDate,
                EndedDate = contract.EndedDate,
                PathImage = contract.PathImage,
                ProjectType = contract.ProjectType,
                Status = contract.Status,
                ProjectId = contract.ProjectId,
                CustomerId = contract.Booking != null ? contract.Booking.CustomerId : null
            })
            .ToListAsync(cancellationToken);
    }
}
