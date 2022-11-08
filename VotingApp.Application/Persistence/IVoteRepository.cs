
using VotingApp.Domain.Entities;

namespace VotingApp.Application.Persistence;

public interface IVoteRepository
{
  Guid Add(Vote vote); 
  Vote? Get(Guid userId, Guid pollId);
}