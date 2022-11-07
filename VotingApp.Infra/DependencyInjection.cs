using Microsoft.Extensions.DependencyInjection;
using VotingApp.Application.Persistence;
using VotingApp.Infra.Persistence;

namespace VotingApp.Infraestructure;

public static class DependencyInjection
{
  public static IServiceCollection AddInfraestructure(
    this IServiceCollection services)
  {
    services.AddScoped<IUserRepository, UserInMemRepository>();
    services.AddScoped<IPollRepository, PollInMemRepository>();
    services.AddScoped<IVoteRepository, VoteInMemRepository>(); 
    return services;
  }
}