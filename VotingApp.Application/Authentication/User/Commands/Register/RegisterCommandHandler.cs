using MediatR;
using VotingApp.Application.Authentication.Register.Commands;
using VotingApp.Application.Persistence;
using VotingApp.Application.Services.Authentication.Common;
using VotingApp.Domain.Entities;


namespace VotingApp.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResult>
{
  private readonly IUserRepository _userRepository;

  public RegisterCommandHandler(IUserRepository userRepository)
  {
    _userRepository = userRepository;
  }

  public async Task<AuthenticationResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
  { 
    if (_userRepository.GetUserByEmail(request.Email) is not null) {
      throw new Exception($"User with email '{request.Email}' already exists");
    }

    var id = Guid.NewGuid();

    var user = new User() {
        Id = id,
        Username = request.Username,
        Email = request.Email,
        Password = request.Password
    };

    _userRepository.Add(user);

    return new AuthenticationResult(user.Email, user.Username, user.Id);
  }
}