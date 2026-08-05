using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.CreateStageImage;

public sealed record CreateStageImageCommand(CreateStageImageDto CreateStageImageDto) : IRequest<Guid>;
