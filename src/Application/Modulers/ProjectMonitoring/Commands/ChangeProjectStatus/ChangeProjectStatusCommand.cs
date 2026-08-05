using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.ChangeProjectStatus;

public sealed record ChangeProjectStatusCommand(ChangeProjectStatusDto ChangeProjectStatusDto) : IRequest;
