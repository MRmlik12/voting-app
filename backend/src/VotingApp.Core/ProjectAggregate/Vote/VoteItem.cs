namespace VotingApp.Core.ProjectAggregate.Vote;

public class VoteItem
{
    public string? FirstName { get; set; }
    public string? SecondName { get; set; }
    public List<VoteUser>? Users { get; set; }
}
