namespace VotingApp.Core.ProjectAggregate.Vote;

public class Vote
{
    public string? Title { get; set; }
    public string KeyHash { get; set; }
    public List<VoteItem>? VotingItems { get; set; }
    public List<Guid>? Participants { get; set; }
}
