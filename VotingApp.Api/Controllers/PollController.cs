using MediatR;
using Microsoft.AspNetCore.Mvc;
using VotingApp.Application.Get.Commands;
using VotingApp.Application.GetActive.Commands;
using VotingApp.Application.GetById.Commands;

namespace VotingApp.Api.Controllers;

[ApiController]
[Route("poll")]
public class PollController : ControllerBase
{
    private readonly ISender _sender;

    public PollController(ISender mediator) 
    {
        _sender = mediator;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var command = new GetPollCommand();
        var getPollResult = await _sender.Send(command);
        return Ok(getPollResult);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Get(Guid id) 
    {
        var command = new GetPollByIdCommand(id);
        var getPollByIdResult = await _sender.Send(command);
        return Ok(getPollByIdResult);
    }

    [HttpGet, Route("active")]
    public async Task<ActionResult> GetActivePolls() 
    {
        var command = new GetActivePollsCommand();
        var getActivePollsResult = await _sender.Send(command);
        return Ok(getActivePollsResult);
    }
}

