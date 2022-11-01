using VotingApp.Domain.Entities;

namespace VotingApp.Application.Get.Commands;

public record GetResult (
  List<Poll> polls
);