using MediatR;

namespace Alkonof_Backend.Application.Modulers.Meetings.Meeting.Commands.RemoveMeeting;

public sealed record RemoveMeetingCommand(Guid Id) : IRequest;
