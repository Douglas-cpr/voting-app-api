using MediatR;
using VotingApp.Domain.Entities;

namespace VotingApp.Application.Create.Commands;
public record CreatePollCommand (
  List<Option> options,
  User user
) : IRequest<CreatePollResult>;