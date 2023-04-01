using VotingApp.Domain.Entities;

namespace VotingApp.Contracts.Poll;
public record PostRequest (
    User User,
    List<Option> Options
);