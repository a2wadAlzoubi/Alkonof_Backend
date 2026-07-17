using MediatR;

namespace Alkonof_Backend.Domain.Common;

public abstract class BaseEvent : INotification
{
    public DateTime OccurredOn { get; set; }
}
