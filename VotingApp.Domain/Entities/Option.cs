namespace VotingApp.Domain.Entities;

public class Option 
{
    public Guid Id { get; set; }
    public string Description { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
}