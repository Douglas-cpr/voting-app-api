using VotingApp.Application.Persistence;
using VotingApp.Domain.Entities;
using VotingApp.Infra.Database;

namespace VotingApp.Infra.Persistence;

public class VoteInMemRepository : IVoteRepository
{
  private readonly InMemoryDatabase _db;

  public VoteInMemRepository() 
  {
    _db = new InMemoryDatabase();
  }

  public Guid Add(Vote vote)
  {
    _db.Add(vote);
    return vote.Id;
  }
}