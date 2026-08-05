using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.UpdateProject;

public sealed record UpdateProjectCommand(UpdateProjectDto UpdateProjectDto) : IRequest;
