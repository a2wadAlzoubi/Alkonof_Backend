using MediatR;

namespace Alkonof_Backend.Application.Modulers.Contracts.Commands.RemoveContract;

public sealed record RemoveContractCommand(Guid Id) : IRequest;
