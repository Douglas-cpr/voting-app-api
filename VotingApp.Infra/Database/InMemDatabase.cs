using VotingApp.Domain.Entities;

namespace VotingApp.Infra.Database;

public class InMemoryDatabase
{
  public List<Poll> GetPollList() {
    var poll_2 = GetRandomPoll();
    poll_2.IsActive = false;
    
    return new List<Poll>() {
      GetRandomPoll(), 
      poll_2
    }; 
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
}

