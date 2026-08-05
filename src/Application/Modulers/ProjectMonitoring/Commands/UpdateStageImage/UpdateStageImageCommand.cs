using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.UpdateStageImage;

public sealed record UpdateStageImageCommand(UpdateStageImageDto UpdateStageImageDto) : IRequest;
