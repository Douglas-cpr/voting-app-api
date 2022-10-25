using VotingApp.Api.Database;
using VotingApp.Api.Entities;
using VotingApp.Api.Repositories;

public class InMemRepository : IPollRepository
{
  public async Task<List<Poll>> GetPollList()
  {
    var polls = InMemoryDatabase.GetPollList();
    var result = await Task.FromResult(polls);
    return result;
  }

  public async Task<Poll> Get(Guid id)
  {
    var poll = InMemoryDatabase
      .GetPollList()
      .Where(p => p.Id == id)
      .FirstOrDefault();
    var result = await Task.FromResult(poll);
    return result;
  }
}