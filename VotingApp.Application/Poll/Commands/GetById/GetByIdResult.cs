using VotingApp.Domain.Entities;

namespace VotingApp.Application.GetById.Commands;

public record GetByIdResult (
  Poll poll
);