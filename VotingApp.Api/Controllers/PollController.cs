using MediatR;
using Microsoft.AspNetCore.Mvc;
using VotingApp.Application.Commands;
using VotingApp.Application.Create.Commands;
using VotingApp.Application.Get.Commands;
using VotingApp.Application.GetActive.Commands;
using VotingApp.Application.GetById.Commands;
using VotingApp.Contracts.Poll;

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
        try
        {
            var command = new GetPollCommand();
            var getPollResult = await _sender.Send(command);
            return Ok(getPollResult);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> Post(PostRequest request) 
    {
        try
        {
            var command = new CreatePollCommand(request.Options, request.User);
            var postPollResult = _sender.Send(command);
            return Ok(postPollResult);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Get(Guid id) 
    {
        try
        {
            var command = new GetPollByIdCommand(id);
            var getPollByIdResult = await _sender.Send(command);
            return Ok(getPollByIdResult);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpGet, Route("active")]
    public async Task<ActionResult> GetActivePolls() 
    {
        try
        {
            var command = new GetActivePollsCommand();
            var getActivePollsResult = await _sender.Send(command);
            return Ok(getActivePollsResult);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpPost, Route("vote")]
    public async Task<ActionResult> Vote(VoteRequest request)
    {
        var command = new VoteCommand(request.pollId, request.optionId, request.userId);
        var voteResult = await _sender.Send(command);
        return Ok(voteResult);
    }
}

