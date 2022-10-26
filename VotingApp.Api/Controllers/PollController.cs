using Microsoft.AspNetCore.Mvc;
using VotingApp.Application.Persistence;

namespace VotingApp.Api.Controllers;

[ApiController]
[Route("poll")]
public class PollController : ControllerBase
{
    private readonly IPollRepository _repository;

    public PollController(IPollRepository repository) 
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var polls = await _repository.Get(); 
        return Ok(polls);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id) 
    {
        var poll = await _repository.Get(id);
        return Ok(poll);
    }

    [HttpGet, Route("active")]
    public async Task<IActionResult> GetActivePolls() 
    {
        var polls = await _repository.Get();
        var activePolls = polls.Where(p => p.IsActive == true);
        return Ok(activePolls);
    }
}
