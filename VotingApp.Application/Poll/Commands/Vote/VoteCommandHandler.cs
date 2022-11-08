using MediatR;
using VotingApp.Application.Persistence;
using VotingApp.Domain.Entities;

namespace VotingApp.Application.Commands;

public class VoteCommandHandler : IRequestHandler<VoteCommand, VoteResult>
{
  private readonly IVoteRepository _voteRepository;
  private readonly IUserRepository _userRepository;
  private readonly IPollRepository _pollRepository;

  public VoteCommandHandler(IVoteRepository voteRepository, IUserRepository userRepository, IPollRepository pollRepository) 
  {
    _voteRepository = voteRepository;
    _userRepository = userRepository;
    _pollRepository = pollRepository;
  }

  public async Task<VoteResult> Handle(VoteCommand request, CancellationToken cancellationToken)
  {
    var user = _userRepository.Get(request.userId);
    if (user is null) throw new ArgumentException($"Don't have any user with ID {request.userId}");

    var poll = _pollRepository.Get(request.pollId);
    if (poll is null) throw new ArgumentException($"Don't have any poll with ID {request.pollId}");

    var alreadyVote = _voteRepository.Get(request.userId, request.pollId);
    if (alreadyVote != null) throw new ArgumentException("Already voted to this poll");

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

    var result = new VoteResult(id);
    return result;
  }
}