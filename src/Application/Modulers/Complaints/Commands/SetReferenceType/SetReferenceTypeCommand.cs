using Alkonof_Backend.Application.Modulers.Complaints.Dtos;
using MediatR;

namespace Alkonof_Backend.Application.Modulers.Complaints.Commands.SetReferenceType;

public sealed record SetReferenceTypeCommand(SetReferenceTypeDto Dto) : IRequest;
