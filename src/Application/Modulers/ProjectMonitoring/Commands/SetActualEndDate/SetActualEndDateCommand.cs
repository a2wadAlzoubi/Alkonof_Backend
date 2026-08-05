using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.SetActualEndDate;

public sealed record SetActualEndDateCommand(SetActualEndDateDto SetActualEndDateDto) : IRequest;
