using VotingApp.Application.Persistence;
using VotingApp.Domain.Entities;
using VotingApp.Infra.Database;

namespace VotingApp.Infra.Persistence;

public class PollInMemRepository : IPollRepository
{
  private readonly InMemoryDatabase _db;

  public PollInMemRepository() 
  {
    _db = new InMemoryDatabase();
  }

  public List<Poll> Get()
  {
    var polls = _db.GetPollList();
    return polls;
  }

  public Poll Get(Guid id)
  {
    var poll = _db.GetRandomPoll(id);
    return poll;
  }
}