using MediatR;
using VotingApp.Application.Authentication.Register.Commands;
using VotingApp.Application.Services.Authentication.Common;
using VotingApp.Domain.Entities;


namespace VotingApp.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResult>
{
  public async Task<AuthenticationResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
  { 
    var user = new User() {
        Id = Guid.NewGuid(),
        Username = request.Username,
        Email = request.Email,
        Password = request.Password
    };

    var authenticationResult = new AuthenticationResult(user);
    var res = await Task.FromResult(authenticationResult);
    return res;
  }
}