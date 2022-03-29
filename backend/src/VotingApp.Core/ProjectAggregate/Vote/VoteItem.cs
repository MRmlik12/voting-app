namespace VotingApp.Core.ProjectAggregate.Vote;

public class VoteItem
{
    public string? FirstName { get; set; }
    public string? SecondName { get; set; }
    public List<string>? FirstVotes { get; set; }
    public List<string>? SecondVotes { get; set; }
}
