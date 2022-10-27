using System;
using MediatR;
using VotingApp.Application.Services.Authentication.Common;

namespace VotingApp.Application.Authentication.Register.Commands;

public record RegisterCommand(
  string Username, 
  string Email, 
  string Password
) : IRequest<AuthenticationResult>;