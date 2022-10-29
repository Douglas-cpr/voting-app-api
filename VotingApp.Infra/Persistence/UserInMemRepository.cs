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

  public async Task<List<User>> Get()
  {
    var polls = _db.GetUserList();
    var result = await Task.FromResult(polls);
    return result;
  }

  public async Task<User> Get(Guid id)
  {
    var poll = _db.GetRandomUser(id);
    var result = await Task.FromResult(poll);
    return result;
  }

  public async Task<Guid> Add(string username, string email, string password)
  {
    var newUser = new User() 
    {
      Id = Guid.NewGuid(),
      Username = username,
      Password = password,
      Email = email
    };
    var result = await Task.FromResult(newUser.Id);
    return result;
  }
}