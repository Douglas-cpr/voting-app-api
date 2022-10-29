
using VotingApp.Domain.Entities;

namespace VotingApp.Application.Persistence;

public interface IUserRepository
{
  List<User> Get(); 
  User? Get(Guid id);
  User? GetUserByEmail(string email);
  Guid Add(User user);
}