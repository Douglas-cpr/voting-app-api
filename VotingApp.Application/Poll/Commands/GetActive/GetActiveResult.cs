using VotingApp.Domain.Entities;

namespace VotingApp.Application.GetActive.Commands;

public record GetActiveResult (
  List<Poll> poll
);