using MediatR;
using VotingApp.Application.Persistence;

namespace VotingApp.Application.GetById.Commands;

public class GetPollByIdCommandHandler : IRequestHandler<GetPollByIdCommand, GetByIdResult>
{
  private readonly IPollRepository _pollRepository;

  public GetPollByIdCommandHandler(IPollRepository pollRepository) 
  {
    _pollRepository = pollRepository;
  }

  public async Task<GetByIdResult> Handle(GetPollByIdCommand request, CancellationToken cancellationToken)
  {
    var polls = _pollRepository.Get(request.id);
    var result = new GetByIdResult(polls);
    return result;
  }
}