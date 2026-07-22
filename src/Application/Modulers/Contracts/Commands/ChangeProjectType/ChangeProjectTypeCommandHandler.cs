using Alkonof_Backend.Application.Common.Interfaces;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Contracts.Commands.ChangeProjectType;

public class ChangeProjectTypeCommandHandler : IRequestHandler<ChangeProjectTypeCommand>
{
    private readonly IApplicationDbContext _context;

    public ChangeProjectTypeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(ChangeProjectTypeCommand request, CancellationToken cancellationToken)
    {
        var contract = await _context.Contract.FindAsync(new object[] { request.Id }, cancellationToken);

        if (contract != null)
        {
            contract.ChangeProjectType(request.Id, request.ProjectType);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
