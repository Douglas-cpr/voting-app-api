using MediatR;
using Microsoft.AspNetCore.Mvc;
using VotingApp.Application.Get.Commands;
using VotingApp.Application.GetById.Commands;
using VotingApp.Application.Persistence;

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
    public ActionResult GetActivePolls() 
    {
        // var polls = _repository.Get();
        // var activePolls = polls.Where(p => p.IsActive == true);
        return Ok("");
    }
}

