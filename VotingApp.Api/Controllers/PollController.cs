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
    public ActionResult Get()
    {
        var polls = _repository.Get(); 
        return Ok(polls);
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

