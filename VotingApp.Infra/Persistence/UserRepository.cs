using VotingApp.Application.Persistence;
using VotingApp.Domain.Entities;
using VotingApp.Infra.Database;

namespace VotingApp.Infra.Persistence;

public class UserInMemRepository : IUserRepository
{
  private readonly InMemoryDatabase _db;

  public UserInMemRepository() 
  {
    _db = new InMemoryDatabase();
  }

  public async Task<List<Poll>> Get()
  {
    var polls = _db.GetPollList();
    var result = await Task.FromResult(polls);
    return result;
  }

  public async Task<Poll> Get(Guid id)
  {
    var poll = _db.GetPollList()
      .Where(p => p.Id == id)
      .FirstOrDefault();
    var result = await Task.FromResult(poll);
    return result;
  }
}