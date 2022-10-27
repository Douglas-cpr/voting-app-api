using VotingApp.Domain.Entities;

namespace VotingApp.Application.Services.Authentication.Common;

public record AuthenticationResult (
  User User
);