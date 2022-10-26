
namespace VotingApp.Application.Authentication.Commands;

public record LoginQuery(
  string Email, 
  string Password
);