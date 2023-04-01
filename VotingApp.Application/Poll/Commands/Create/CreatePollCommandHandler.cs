using MediatR;
using VotingApp.Application.Get.Commands;
using VotingApp.Application.Persistence;

namespace VotingApp.Application.Create.Commands;

public class CreatePollCommandHandler : IRequestHandler<CreatePollCommand, CreatePollResult>
{
  private readonly IPollRepository _pollRepository;

  public CreatePollCommandHandler(IPollRepository pollRepository) 
  {
    _pollRepository = pollRepository;
  }

  public async Task<CreatePollResult> Handle(CreatePollCommand request, CancellationToken cancellationToken)
  {
    var polls =  _pollRepository.Get();
    var result = new CreatePollCommand(polls);
    return result;
  }
}