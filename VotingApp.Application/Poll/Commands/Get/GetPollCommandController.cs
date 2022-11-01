using MediatR;
using VotingApp.Application.Persistence;

namespace VotingApp.Application.Get.Commands;

public class GetPollCommandHandler : IRequestHandler<GetPollCommand, GetResult>
{
  private readonly IPollRepository _pollRepository;

  public GetPollCommandHandler(IPollRepository pollRepository) 
  {
    _pollRepository = pollRepository;
  }

  public async Task<GetResult> Handle(GetPollCommand request, CancellationToken cancellationToken)
  {
    var polls = _pollRepository.Get();
    var result = new GetResult(polls);
    return result;
  }
}