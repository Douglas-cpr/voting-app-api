using VotingApp.Domain.Entities;

namespace VotingApp.Infra.Database;

public class InMemoryDatabase
{
   private readonly List<Poll> _polls;
   private readonly List<User> _users;

  public InMemoryDatabase() 
  {
    _polls = new() 
    { 
      GetRandomPoll(),
      GetRandomPoll(),
      GetRandomPoll()
    };
    
    _users = new()
    {
      GetRandomUser(),
      GetRandomUser(),
      GetRandomUser()
    };
  }

  public List<Poll> GetPollList() 
  {
    return _polls;
  }

  public List<User> GetUserList() 
  {
    return _users;
  }

  public Poll GetRandomPoll(Guid id) 
  {
    var poll = _polls.First();
    poll.Id = id;
    return poll;
  }

  public User GetRandomUser(Guid id) 
  {
    var user = _users.First();
    user.Id = id;
    return user;
  }

  private Poll GetRandomPoll() 
  {
    return new Poll() {
      Id = Guid.NewGuid(),
      IsActive = true,
      User = new User() {
        Id = Guid.NewGuid(),
        Username = "John Doe" + DateTime.Now.ToString(),
        Email = "John.Doe@gmail.com",
        Password = "password@gmail.com"
      },
      Options = new List<Option>() {
        new Option {
          Id = Guid.NewGuid(),
          Description = "Random Option 1",
          CreatedAt = DateTime.Now,
        },
        new Option {
          Id = Guid.NewGuid(),
          Description = "Random Option 2",
          CreatedAt = DateTime.Now,
        }
      }
    };
  }

  private User GetRandomUser() 
  {
    return new User() 
    {
      Id = Guid.NewGuid(),
      Username = "username1",
      Email = "email1@hotmail.com",
      Password = "password1@"
    };
  }
}

