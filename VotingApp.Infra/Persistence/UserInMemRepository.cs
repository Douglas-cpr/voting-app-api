using System.Runtime.InteropServices.ComTypes;
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

  public List<User> Get()
  {
    var polls = _db.GetUserList();
    return polls;
  }

  public User? Get(Guid id)
  {
    var poll = _db.GetRandomUser(id);
    return poll;
  }

  public Guid Add(User user)
  {
    return user.Id;
  }

  public User? GetUserByEmail(string email)
  {
    var users = _db.GetUserList();
    var user = users.FirstOrDefault(u => u.Email == email);
    return user;
  }
}