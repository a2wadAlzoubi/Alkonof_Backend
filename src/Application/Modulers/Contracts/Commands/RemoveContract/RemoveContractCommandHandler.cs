using Alkonof_Backend.Application.Common.Interfaces;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Contracts.Commands.RemoveContract;

public class RemoveContractCommandHandler : IRequestHandler<RemoveContractCommand>
{
    private readonly IApplicationDbContext _context;

    public RemoveContractCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(RemoveContractCommand request, CancellationToken cancellationToken)
    {
        var contract = await _context.Contract.FindAsync(new object[] { request.Id }, cancellationToken);

        if (contract != null)
        {
            _context.Contract.Remove(contract);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
