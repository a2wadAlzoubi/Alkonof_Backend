using Alkonof_Backend.Application.Modulers.Meetings.PrepareMeeting.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Meetings.PrepareMeeting.Commands.UpdatePrepareMeeting;

public sealed record UpdatePrepareMeetingCommand(PrepareMeetingDto Dto) : IRequest;
