
using VotingApp.Domain.Entities;

namespace VotingApp.Application.Persistence;

public interface IPollRepository
{
  Task<List<Poll>> Get(); 
  Task<Poll> Get(Guid id);
}