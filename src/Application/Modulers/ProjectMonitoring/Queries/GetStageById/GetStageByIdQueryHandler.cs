using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Queries.GetStageById;

public class GetStageByIdQueryHandler : IRequestHandler<GetStageByIdQuery, StageDto?>
{
    private readonly IApplicationDbContext _context;

    public GetStageByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<StageDto?> Handle(GetStageByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Stage
            .ProjectToType<StageDto>()
            .FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);
    }
}
