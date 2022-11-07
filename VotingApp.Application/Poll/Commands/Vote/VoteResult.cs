namespace VotingApp.Application.Commands;

public record VoteResult (
  Guid voteId,
  Guid optionId
);