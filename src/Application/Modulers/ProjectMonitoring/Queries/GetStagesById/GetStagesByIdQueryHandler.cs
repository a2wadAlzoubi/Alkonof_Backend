using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Queries.GetStagesById;

public class GetStagesByIdQueryHandler : IRequestHandler<GetStagesByIdQuery, StageDto?>
{
    private readonly IApplicationDbContext _context;

    public GetStagesByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<StageDto?> Handle(GetStagesByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Stage
            .ProjectToType<StageDto>()
            .FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);
    }
}
