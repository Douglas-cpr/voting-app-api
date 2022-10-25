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
    public async Task<List<Poll>> Get()
    {
        var polls = await _repository.GetPollList(); 
        return polls;
    }

    [HttpGet("{id}")]
    public async Task<Poll> Get(Guid id) 
    {
        var poll = await _repository.Get(id);
        return poll;
    }
}
