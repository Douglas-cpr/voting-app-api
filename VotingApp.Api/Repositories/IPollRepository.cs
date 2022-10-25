
using VotingApp.Api.Entities;

namespace VotingApp.Api.Repositories;

public interface IPollRepository
{
  Task<List<Poll>> GetPollList(); 
  Task<Poll> Get(Guid id);
}