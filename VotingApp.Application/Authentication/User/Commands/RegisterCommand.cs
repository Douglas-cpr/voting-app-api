using System;

namespace VotingApp.Application.Authentication.Commands;

public record RegisterCommand(
  string Username, 
  string Email, 
  string Password
);