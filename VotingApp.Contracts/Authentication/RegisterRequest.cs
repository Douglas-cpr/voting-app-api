namespace VotingApp.Contracts.Authentication;

public record RegisterRequest (
  string username,
  string password,
  string email
);