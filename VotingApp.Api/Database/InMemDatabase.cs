using System;
using VotingApp.Api.Entities;

namespace VotingApp.Api.Database;

public static class InMemoryDatabase
{
  public static List<Poll> GetPollList() {
    var poll_2 = InMemoryDatabase.GetRandomPoll();
    poll_2.IsActive = false;
    
    return new List<Poll>() {
      InMemoryDatabase.GetRandomPoll(), 
      poll_2
    }; 
  }

  private static Poll GetRandomPoll() 
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

