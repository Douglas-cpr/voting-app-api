using MediatR;
using VotingApp.Application.Persistence;
using VotingApp.Application.Services.Authentication.Common;

namespace VotingApp.Application.Authentication.Commands.Authenticate;


public class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, AuthenticationResult>
{
  private readonly IUserRepository _userRepository;

  public AuthenticateCommandHandler(IUserRepository userRepository) 
  {
    _userRepository = userRepository;
  }

  public async Task<AuthenticationResult> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
  {
    var user = _userRepository.GetUserByEmail(request.Email);

    if (user is null) {
      throw new Exception($"Don't exists any user with email {request.Email}.");
    }

    if (!request.Password.Equals(user.Password)) {
      throw new Exception($"Invalid password {request.Password}.");
    }

    return new AuthenticationResult(user.Email, user.Username, user.Id);
  }
}