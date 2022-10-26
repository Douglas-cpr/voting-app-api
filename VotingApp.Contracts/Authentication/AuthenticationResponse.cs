 namespace VotingApp.Contracts.Authentication;

public record AuthenticationResponse (
  string Username,
  string Email,
  Guid Id
);