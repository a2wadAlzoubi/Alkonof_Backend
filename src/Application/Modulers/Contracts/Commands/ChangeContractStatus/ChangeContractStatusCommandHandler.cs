using Alkonof_Backend.Application.Common.Interfaces;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Contracts.Commands.ChangeContractStatus;

public class ChangeContractStatusCommandHandler : IRequestHandler<ChangeContractStatusCommand>
{
    private readonly IApplicationDbContext _context;

    public ChangeContractStatusCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(ChangeContractStatusCommand request, CancellationToken cancellationToken)
    {
        var contract = await _context.Contract.FindAsync(new object[] { request.Id }, cancellationToken);

        if (contract != null)
        {
            contract.ChangeContractStatus(request.Id, request.Status);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
