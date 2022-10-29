
using VotingApp.Domain.Entities;

namespace VotingApp.Application.Persistence;

public interface IUserRepository
{
  Task<List<User>> Get(); 
  Task<User> Get(Guid id);
  Task<Guid> Add(string username, string email, string password);
}