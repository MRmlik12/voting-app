namespace VotingApp.Core.ProjectAggregate.Vote;

public class VoteModel
{
    public string? Title { get; set; }
    public List<VoteItem>? VotingItems { get; set; }
    public List<Guid>? Participants { get; set; }
}
