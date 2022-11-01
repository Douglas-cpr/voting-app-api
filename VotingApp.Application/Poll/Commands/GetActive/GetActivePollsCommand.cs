using MediatR;

namespace VotingApp.Application.GetActive.Commands;
public record GetActivePollsCommand () : IRequest<GetActiveResult>;