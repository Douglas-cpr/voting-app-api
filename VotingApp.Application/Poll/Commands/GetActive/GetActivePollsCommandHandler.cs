using MediatR;
using VotingApp.Application.Persistence;

namespace VotingApp.Application.GetActive.Commands;

public class GetActivePollsCommandHandler : IRequestHandler<GetActivePollsCommand, GetActiveResult>
{
  private readonly IPollRepository _pollRepository;

  public GetActivePollsCommandHandler(IPollRepository pollRepository) 
  {
    _pollRepository = pollRepository;
  }

  public async Task<GetActiveResult> Handle(GetActivePollsCommand request, CancellationToken cancellationToken)
  {
    var polls = _pollRepository.Get();
    var active = polls.Where(p => p.IsActive == true).ToList();
    var result = new GetActiveResult(active);
    return result;
  }
}