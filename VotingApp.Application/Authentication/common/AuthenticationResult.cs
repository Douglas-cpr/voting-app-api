namespace VotingApp.Application.Services.Authentication.Common;

public record AuthenticationResult (
  string Email,
  string Username,
  Guid Id
);