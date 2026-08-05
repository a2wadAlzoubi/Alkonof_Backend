using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.CreateProject;

public sealed record CreateProjectCommand(CreateProjectDto CreateProjectDto) : IRequest<Guid>;
