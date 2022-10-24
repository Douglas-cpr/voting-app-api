using Microsoft.AspNetCore.Mvc;
using VotingApp.Api.Entities;

namespace VotingApp.Api.Controllers;

[ApiController]
[Route("poll")]
public class WeatherForecastController : ControllerBase
{
    public WeatherForecastController() {}

    [HttpGet]
    public async Task<Poll[]> Get()
    {
        var polls = new Poll[] { };
        var task = Task.FromResult(polls);
        return await task;
    }
}
