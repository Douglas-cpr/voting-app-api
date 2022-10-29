
using VotingApp.Domain.Entities;

namespace VotingApp.Application.Persistence;

public interface IPollRepository
{
  List<Poll> Get(); 
  Poll Get(Guid id);
}