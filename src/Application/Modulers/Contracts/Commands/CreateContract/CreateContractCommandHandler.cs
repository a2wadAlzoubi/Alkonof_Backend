using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Contracts;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Contracts.Commands.CreateContract;

public class CreateContractCommandHandler : IRequestHandler<CreateContractCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateContractCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateContractCommand request, CancellationToken cancellationToken)
    {
        var contract = Contract.CreateContract(
            request.ContractDto.StartedDate,
            request.ContractDto.EndedDate ?? default,
            request.ContractDto.PathImage,
            request.ContractDto.ProjectType,
            request.ContractDto.Status,
            request.ContractDto.ProjectId
        );

        // How to associate CustomerId? The Domain entity does not seem to have a direct way.
        // I will assume for now that the relationship is managed elsewhere or needs to be added.
        // For now, I will add the contract to the context and save.

        await _context.Contract.AddAsync(contract, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return contract.Id;
    }
}
