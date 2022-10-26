namespace VotingApp.Domain.Entities;

public class Poll
{
    public Guid Id { get; set; }         
    public User User { get; set; } = null!;
    public List<Option> Options { get; set; } = null!;
    public bool IsActive { get; set; }
}
