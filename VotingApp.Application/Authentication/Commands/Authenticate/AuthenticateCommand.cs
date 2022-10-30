using MediatR;
using VotingApp.Application.Services.Authentication.Common;

namespace VotingApp.Application.Authentication.Commands.Authenticate;
public record AuthenticateCommand (
  string Email,
  string Password
) : IRequest<AuthenticationResult>;