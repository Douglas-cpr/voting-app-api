namespace VotingApp.Domain.Entities;

public class Vote 
{
    public Guid Id { get; set; } 
    public Guid OptionId { get; set; }
    public Guid PollId { get; set; }
    public Guid UserId { get; set; }
    public DateTime VoteDate { get; set; }
}