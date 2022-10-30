using MediatR;
using Microsoft.AspNetCore.Mvc;
using VotingApp.Application.Authentication.Commands.Authenticate;
using VotingApp.Application.Authentication.Commands.Register;
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
      try
      {
        var command = new RegisterCommand(request.username, request.email, request.password);
        var registerResult = await _sender.Send(command);
        return Ok(registerResult);
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
      }
    }

    [HttpPost, Route("authenticate")]
    public async Task<ActionResult> Authenticate(AuthenticateRequest request)
    {
      try
      {
        var command = new AuthenticateCommand(request.email, request.password);
        var authenticateResult = await _sender.Send(command);
        return Ok(authenticateResult);
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
      }
    }
}
