using System;

namespace VotingApp.Application.Authentication.Commands;

public record AuthenticateCommand (
  string Email,
  string Password
);