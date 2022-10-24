namespace VotingApp.Api.Entities;

public class Poll
{
    public int Id { get; set; }         
    public User User { get; set; } = null!;
    public Option[] Options { get; set; } = null!;
    public bool IsActive { get; set; }
}
