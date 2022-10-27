namespace VotingApp.Contracts.Authentication;
public record AuthenticateRequest (
  string email,
  string password
);