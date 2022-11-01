using MediatR;

namespace VotingApp.Application.Get.Commands;
public record GetPollCommand () : IRequest<GetResult>;