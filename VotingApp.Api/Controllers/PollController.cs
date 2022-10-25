using System.Reflection.Emit;
using Microsoft.AspNetCore.Mvc;
using VotingApp.Api.Entities;
using VotingApp.Api.Database;
using VotingApp.Api.Repositories;

namespace VotingApp.Api.Controllers;

[ApiController]
[Route("poll")]
public class WeatherForecastController : ControllerBase
{
    private readonly IPollRepository _repository;

    public WeatherForecastController(IPollRepository repository) 
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var polls = await _repository.GetPollList(); 
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
        var polls = await _repository.GetPollList();
        var activePolls = polls.Where(p => p.IsActive == true);
        return Ok(activePolls);
    }
}
