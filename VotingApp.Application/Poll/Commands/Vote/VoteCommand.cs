using MediatR;

namespace VotingApp.Application.Commands;
public record VoteCommand (
  Guid pollId,
  Guid optionId,
  Guid userId
) : IRequest<VoteResult>;