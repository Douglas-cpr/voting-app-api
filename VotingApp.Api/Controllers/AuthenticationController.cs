using Microsoft.AspNetCore.Mvc;
using VotingApp.Application.Authentication.Commands;
using VotingApp.Application.Authentication.Register.Commands;
using VotingApp.Application.Persistence;
using VotingApp.Contracts.Authentication;

namespace VotingApp.Api.Controllers;

[ApiController]
[Route("authentication")]
public class AuthenticationController : ControllerBase
{
    private readonly IPollRepository _repository;

    public AuthenticationController(IPollRepository repository) 
    {
        _repository = repository;
    }

    [HttpPost, Route("register")]
    public async Task<ActionResult> Register(RegisterRequest request) 
    {
      var command = new RegisterCommand(request.username, request.email, request.password);
      // call handler
      var response = new AuthenticationResponse(request.username, request.email, Guid.NewGuid());
      var res = await Task.FromResult(response);
      return Ok(res);
    }

    [HttpPost, Route("authenticate")]
    public async Task<ActionResult> Authenticate(AuthenticateRequest request)
    {
      var command = new AuthenticateCommand(request.email, request.password);
      // do someting with command
      var response = new AuthenticationResponse("username", request.email, Guid.NewGuid());
      var res = await Task.FromResult(response);
      return Ok(res);
    }
}
