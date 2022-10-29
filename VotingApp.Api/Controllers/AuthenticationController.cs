using MediatR;
using Microsoft.AspNetCore.Mvc;
using VotingApp.Application.Authentication.Commands;
using VotingApp.Application.Authentication.Register.Commands;
using VotingApp.Contracts.Authentication;

namespace VotingApp.Api.Controllers;

[ApiController]
[Route("authentication")]
public class AuthenticationController : ControllerBase
{

  private readonly ISender _sender;

    public AuthenticationController(ISender mediator) 
    {
      _sender = mediator;
    }

    [HttpPost, Route("register")]
    public async Task<ActionResult> Register(RegisterRequest request) 
    {
      var command = new RegisterCommand(request.username, request.email, request.password);
      var registerResult = await _sender.Send(command);
      return Ok(registerResult);
    }

    [HttpPost, Route("authenticate")]
    public async Task<ActionResult> Authenticate(AuthenticateRequest request)
    {
      var command = new AuthenticateCommand(request.email, request.password);
      var response = new AuthenticationResponse("username", request.email, Guid.NewGuid());
      var res = await Task.FromResult(response);
      return Ok(res);
    }
}
