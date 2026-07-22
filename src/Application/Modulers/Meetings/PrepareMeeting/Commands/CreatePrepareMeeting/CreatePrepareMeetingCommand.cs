using Alkonof_Backend.Application.Modulers.Meetings.PrepareMeeting.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Meetings.PrepareMeeting.Commands.CreatePrepareMeeting;

public sealed record CreatePrepareMeetingCommand(CreatePrepareMeetingDto Dto) : IRequest<Guid>;
