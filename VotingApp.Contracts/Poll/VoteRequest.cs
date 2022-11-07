namespace VotingApp.Contracts.Poll;
public record VoteRequest (
  Guid pollId,
  Guid optionId,
  Guid userId
);