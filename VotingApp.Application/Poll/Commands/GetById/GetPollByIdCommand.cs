using MediatR;

namespace VotingApp.Application.GetById.Commands;
public record GetPollByIdCommand (
  Guid id
) : IRequest<GetByIdResult>;