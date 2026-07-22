using Alkonof_Backend.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Contracts.Commands.UpdateContract;

public class UpdateContractCommandHandler : IRequestHandler<UpdateContractCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateContractCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateContractCommand request, CancellationToken cancellationToken)
    {
        var contract = await _context.Contract.FindAsync(new object[] { request.Id }, cancellationToken);

        if (contract == null)
        {
            // Or throw a NotFoundException
            return;
        }

        contract.UpdateContract(
            request.Id,
            request.ContractDto.StartedDate,
            request.ContractDto.EndedDate ?? default,
            request.ContractDto.PathImage,
            request.ContractDto.ProjectType,
            request.ContractDto.Status,
            request.ContractDto.ProjectId ?? Guid.Empty
        );

        await _context.SaveChangesAsync(cancellationToken);
    }
}
