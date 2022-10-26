
using VotingApp.Domain.Entities;

namespace VotingApp.Application.Persistence;

public interface IUserRepository
{
  Task<List<Poll>> Get(); 
  Task<Poll> Get(Guid id);
}