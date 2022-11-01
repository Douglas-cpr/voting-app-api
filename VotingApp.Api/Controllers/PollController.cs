using MediatR;
using Microsoft.AspNetCore.Mvc;
using VotingApp.Application.Get.Commands;
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
    public ActionResult Get(Guid id) 
    {
        var poll = _repository.Get(id);
        return Ok(poll);
    }

    [HttpGet, Route("active")]
    public ActionResult GetActivePolls() 
    {
        var polls = _repository.Get();
        var activePolls = polls.Where(p => p.IsActive == true);
        return Ok(activePolls);
    }
}

