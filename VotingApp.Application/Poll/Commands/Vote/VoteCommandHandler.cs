using MediatR;
using VotingApp.Application.Persistence;
using VotingApp.Domain.Entities;

namespace VotingApp.Application.Commands;

public class VoteCommandHandler : IRequestHandler<VoteCommand, VoteResult>
{
  private readonly IVoteRepository _voteRepository;

  public VoteCommandHandler(IVoteRepository voteRepository) 
  {
    _voteRepository = voteRepository;
  }

  public async Task<VoteResult> Handle(VoteCommand request, CancellationToken cancellationToken)
  {
    var id = Guid.NewGuid();

    var vote = new Vote()
    {
      Id = id,
      UserId = request.userId,
      PollId = request.pollId,
      OptionId = request.optionId,
      VoteDate = DateTime.Now
    };

    _voteRepository.Add(vote);

    var result = new VoteResult(id, request.optionId);
    return result;
  }
}