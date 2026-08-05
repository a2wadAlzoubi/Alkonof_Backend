using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.SetProjectProgress;

public sealed record SetProjectProgressCommand(SetProjectProgressDto SetProjectProgressDto) : IRequest;
