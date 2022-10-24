namespace VotingApp.Api.Entities;

public class Option 
{
    public string Id { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime CreatedAt { get; set; }

}